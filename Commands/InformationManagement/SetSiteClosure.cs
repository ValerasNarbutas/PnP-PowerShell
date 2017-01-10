﻿using System.Management.Automation;
using Microsoft.SharePoint.Client;
using SharePointPnP.PowerShell.CmdletHelpAttributes;

namespace SharePointPnP.PowerShell.Commands.InformationManagement
{
    [Cmdlet(VerbsCommon.Set, "PnPSiteClosure")]
    [CmdletAlias("Set-SPOSiteClosure")]
    [CmdletHelp("Opens or closes a site which has a site policy applied", Category = CmdletHelpCategory.InformationManagement)]
    [CmdletExample(
      Code = @"PS:> Set-PnPSiteClosure -State Open",
      Remarks = @"This opens a site which has been closed and has a site policy applied.", SortOrder = 1)]
    [CmdletExample(
      Code = @"PS:> Set-PnPSiteClosure -State Closed",
      Remarks = @"This closes a site which is open and has a site policy applied.", SortOrder = 2)]
    public class SetSiteClosure : SPOWebCmdlet
    {
        [Parameter(Mandatory = true, HelpMessage = "The state of the site")]
        public ClosureState State;

        protected override void ExecuteCmdlet()
        {
            if (State == ClosureState.Open)
            {
                SelectedWeb.SetOpenBySitePolicy();
            } else if (State == ClosureState.Closed)
            {
                SelectedWeb.SetClosedBySitePolicy();
            }
        }
    }
}
