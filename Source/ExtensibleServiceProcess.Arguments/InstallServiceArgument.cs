﻿using System;
using System.ComponentModel.Composition;
using Arguments;

namespace ExtensibleServiceProcess.Arguments
{
    /// <summary>
    /// The argument used to install an ExtensibleServiceProcess application.
    /// </summary>
    /// <seealso cref="IArgument" />
    public class InstallServiceArgument : IArgument
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InstallServiceArgument"/> class.
        /// </summary>
        /// <param name="service">The argument action target service.</param>
        [ImportingConstructor]
        public InstallServiceArgument(ExtensibleServiceBase service)
        {
            Action = InstallService;
            Target = service;
        }

        /// <summary>
        /// The action to perform when the argument is specified.
        /// </summary>
        /// <value>The action.</value>
        public Action<object, string> Action { get; set; }

        /// <summary>
        /// The possible flags used to denote the argument.
        /// </summary>
        /// <value>The flags.</value>
        public string[] Flags { get; set; } = { "i", "install" };

        /// <summary>
        /// Gets or sets the argument action target.
        /// </summary>
        /// <value>The target.</value>
        public object Target { get; set; }

        /// <summary>
        /// Determines if additional arguments should be processed if this argument is encountered and executed.
        /// </summary>
        /// <value><c>true</c> if terminate after execution; otherwise, <c>false</c>.</value>
        public bool TerminateAfterExecution { get; set; } = true;

        private void InstallService(object target, string parameter)
        {
            var service = target as ExtensibleServiceBase;
            service?.InstallService();
        }
    }
}