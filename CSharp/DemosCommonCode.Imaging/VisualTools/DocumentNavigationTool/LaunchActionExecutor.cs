﻿using System;
using System.Diagnostics;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.Metadata;
using Vintasoft.Imaging.UI;
using Vintasoft.Imaging.UI.VisualTools;

namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// Represents an executor of "Launch" actions that launches other applications.
    /// </summary>
    public class LaunchActionExecutor : IPageContentActionExecutor
    {

        /// <summary>
        /// Executes the action.
        /// </summary>
        /// <param name="viewer">Image viewer.</param>
        /// <param name="image">Instance of <see cref="VintasoftImage"/> on which action will be executed.</param>
        /// <param name="action">The action.</param>
        /// <returns><b>True</b> if action is executed; otherwise, <b>false</b>.</returns>
        public bool ExecuteAction(ImageViewer viewer, VintasoftImage image, PageContentActionMetadata action)
        {
            LaunchActionMetadata launchAction = action as LaunchActionMetadata;
            if (launchAction != null)
            {
                if (launchAction.CommandLine != "")
                {
                    if (MessageBox.Show(string.Format("Start application '{0}' ?", launchAction.CommandLine), "Execute an application", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        try
                        {
                            Process.Start(launchAction.CommandLine);
                        }
                        catch (Exception exc)
                        {
                            DemosTools.ShowErrorMessage(exc);
                            return false;
                        }
                    }

                    return true;
                }
            }
            return false;
        }

    }
}
