# To run under powershell 7 use:  pwsh KenSetupWinformCallsMsgraph.ps1
# You must set variable $DomainName in this script before running the script!
# That variable is located a few lines after all the 'functions' which appear first in the script.
# Create a user
#     Reference: https://learn.microsoft.com/en-us/graph/api/user-post-users?view=graph-rest-1.0&tabs=powershell
# Create a group
#     Reference: https://learn.microsoft.com/en-us/graph/api/group-post-groups?view=graph-rest-1.0&tabs=powershell  (example 2)
# Add a member to a group
#     Reference: https://learn.microsoft.com/en-us/graph/api/group-post-members?view=graph-rest-1.0&tabs=powershell
# ===================================
# Cteate a user if not already exists
# ===================================
function New-User
{
    Param($DomainName, $UserName, $Password)
    $varUser = Get-MgUser -Filter "userPrincipalName eq '$UserName@$($DomainName)'"
    if ($varUser -ne $null)  
    {
        Write-Host  "$UserName already exists."
    }
    else
    {
        $params = @{
	    accountEnabled = $true
	    displayName = $UserName    
            mailNickname = $UserName
	    userPrincipalName = "$UserName@$DomainName"
	    passwordProfile = @{
		forceChangePasswordNextSignIn = $false
		password = $Password
	    }
        }
        Write-Host  "$UserName being created."
        New-MgUser -BodyParameter $params
    }
}
# ===========================================================================================
# Create a DEMO group (delete/recreate if already exists in order to ensure it has no members)
# ===========================================================================================
function New-DemoGroup
{
    Param($GroupName)
    if ($GroupName.StartsWith("DemoGroup") -eq $false)
    {
        Write-Host "$GroupName cannot be created/deleted because only groups named DemoGroup* are allowed."
    }
    else
    {
        $varGroup = Get-MgGroup -Filter "DisplayName eq '$GroupName'"
        # if group exists then delete it
        if ($varGroup -ne $null)
        {
            Write-Host "$GroupName is being deleted."
            Remove-MgGroup -GroupId $varGroup.Id | Out-Null
        }
        # create a new group
        $params = @{
	    description = "Tutorial group $GroupName"
	    displayName = $GroupName
	    groupTypes = @()
            mailEnabled = $false
            mailNickname = $GroupName
            securityEnabled = $true
            }
        Write-Host "$GroupName is being created."
        New-MgGroup -BodyParameter $params | Out-Null
    }
}
# ==== We do not currently use this function =================
# Creates a new group with a member of type user; 
# if $userId is null then the group is created with no members.
# =============================================================
function New-GroupWithUserMember
{
    Param($GroupName, $UserId)
    $params = @{
	description = "Demo group $GroupName"
	displayName = $GroupName
	groupTypes = @()
        mailEnabled = $false
        mailNickname = $GroupName
        securityEnabled = $true
        "members@odata.bind" = @(
            "https://graph.microsoft.com/v1.0/users/$UserId"
        )
    }
    if ($UserId -eq $null)
    {
        # remove key-value from hashtable 
        $params.Remove("members@odata.bind")
    }
    New-MgGroup -BodyParameter $params
}

# ====================================================================
# Adds an existing group (subgroup) to an existing group (parentGroup). 
# ====================================================================
function Add-SubgroupToGroup
{
    Param($ParentGroupName, $SubgroupName)
    $ParentGroupId = $null
    $SubgroupId = $null
    $varParentGroup = Get-MgGroup -Filter "DisplayName eq '$ParentGroupName'"
    $varSubgroup = Get-MgGroup -Filter "DisplayName eq '$SubgroupName'"
    $errmssg = $null
    if ($varParentGroup -ne $null)  
    {
        $ParentGroupId = $varParentGroup.Id
    }
    else
    {
         $errmssg = "Error! ${ParentGroupName} not found."
    }
    if ($varSubgroup -ne $null)  
    {
        $SubgroupId = $varSubgroup.Id
    }
    else
    {
         $errmssg = "Error! ${SubgroupName} not found."
    }
    if ($errmssg -eq $null)
    {
        $params = @{
	    "@odata.id" = "https://graph.microsoft.com/v1.0/directoryObjects/$SubgroupId"
        }
        Write-Host "Structuring subgroup. ParentGroup=${ParentGroupName} Subgroup=${SubgroupName}"
        New-MgGroupMemberByRef -GroupId $ParentGroupId -BodyParameter $params
    }
    else
    {
        Write-Host "${errmssg}"
    }
}
# ===========================================
# Adds an existing user to an existing group.
# ===========================================
function Add-UserToGroup
{
    Param($GroupName, $UserPrincipalName)
    $GroupId = $null
    $UserId = $null
    $varGroup = Get-MgGroup -Filter "DisplayName eq '$GroupName'"
    $varUser = Get-MgUser -Filter "userPrincipalName eq '$UserPrincipalName'"
    $errmssg = $null
    if ($varGroup -ne $null)  
    {
        $GroupId = $varGroup.Id
    }
    else
    {
         $errmssg = "Error! ${GroupName} not found."
    }
    if ($varUser -ne $null)  
    {
        $UserId = $varUser.Id
    }
    else
    {
         $errmssg = "Error! ${UserPrincipalName} not found."
    }
    if ($errmssg -eq $null)
    {
        $params = @{
	    "@odata.id" = "https://graph.microsoft.com/v1.0/directoryObjects/$UserId"
        }
        Write-Host "Adding ${UserPrincipalName} to ${GroupName}."
        New-MgGroupMemberByRef -GroupId $GroupId -BodyParameter $params
    }
    else
    {
        Write-Host "${errmssg}"
    }
}
Write-Host '==================================================================='
Write-Host 'This creates (or re-creates) all users and groups for the tutorial.'
Write-Host '==================================================================='
$userResponse = Read-Host 'Do you want to proceed? Y/N'
if ($userResponse.ToUpper() -ne 'Y')
{
    Exit
}
Write-Host "About to connect to msgraph"
Connect-MgGraph -Scopes ("User.ReadWrite.All", "Directory.ReadWrite.All", "GroupMember.ReadWrite.All", "Group.ReadWrite.All")
$DomainName = 'kensmithsoftware.com'
$InitialPW = 'P2#Horizon'

New-User -DomainName $DomainName -UserName "Karla"    -Password $InitialPW
New-User -DomainName $DomainName -UserName "Kathy"    -Password $InitialPW
New-User -DomainName $DomainName -UserName "Kellette" -Password $InitialPW
New-User -DomainName $DomainName -UserName "Ed"       -Password $InitialPW
# Later, Kenadmin must be assigned roles with authority to create users and create/delete groups!
# Those roles could be Groups Admimistrator, User Administrator, Global Administrator, etc.
New-User -DomainName $DomainName -UserName "Kenadmin" -Password $InitialPW

New-DemoGroup -GroupName "DemoGroupBilling"
New-DemoGroup -GroupName "DemoGroupAppeals"
New-DemoGroup -GroupName "DemoGroupMarketing"
New-DemoGroup -GroupName "DemoGroupAdmin"
New-DemoGroup -GroupName "DemoGroupStaff"

Add-UserToGroup -GroupName "DemoGroupBilling"    -UserPrincipalName "Karla@${DomainName}"
Add-UserToGroup -GroupName "DemoGroupAppeals"    -UserPrincipalName "Kathy@${DomainName}"
Add-UserToGroup -GroupName "DemoGroupMarketing"  -UserPrincipalName "Kellette@${DomainName}"
Add-UserToGroup -GroupName "DemoGroupAdmin"      -UserPrincipalName "Kenadmin@${DomainName}"
Add-UserToGroup -GroupName "DemoGroupAdmin"      -UserPrincipalName "Ed@${DomainName}"

Add-SubgroupToGroup -ParentGroupName "DemoGroupStaff"   -SubgroupName "DemoGroupMarketing"
Add-SubgroupToGroup -ParentGroupName "DemoGroupStaff"   -SubgroupName "DemoGroupBilling"
Add-SubgroupToGroup -ParentGroupName "DemoGroupBilling" -SubgroupName "DemoGroupAppeals"

Write-Host "About to disconnect from msgraph"
Disconnect-MgGraph
