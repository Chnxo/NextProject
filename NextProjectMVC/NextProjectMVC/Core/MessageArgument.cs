using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace NextProjectMVC.Core
{
    /// <summary>
    /// Lists the possible actions to be performed by a message handler.
    /// </summary>
    /// <remarks></remarks>
    public enum MessageAction
    {
        /// <summary>
        /// A request to save the item to the data store.
        /// </summary>
        Save,

        /// <summary>
        /// A request to get a single item by ID.
        /// </summary>
        Get,

        /// <summary>
        /// A request to get all the items.
        /// </summary>
        GetAll,

        /// <summary>
        /// A request  to edit a single item
        /// </summary>
        Edit,

        /// <summary>
        /// A request to delete a single item
        /// </summary>
        Delete,

        /// <summary>
        /// Represents a custom action. More information has to be provided through the parameters and the custom action property.
        /// </summary>
        Custom
    }

    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="TPar">The type of the parameter.</typeparam>
    /// <remarks></remarks>
    public class MessageArgument<TPar>
    {
        private readonly dynamic _parameters = new ExpandoObject();

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageArgument&lt;TPar&gt;"/> class.
        /// </summary>
        /// <remarks></remarks>
        public MessageArgument()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageArgument&lt;TPar&gt;"/> class.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <remarks></remarks>
        public MessageArgument(TPar parameter)
        {
            MainParameter = parameter;
        }

        /// <summary>
        /// Gets the parameters.
        /// </summary>
        /// <remarks></remarks>
        public dynamic Parameters
        {
            get { return _parameters; }

            //set { _Parameters = value; }
        }

        /// <summary>
        /// Gets or sets the ID to be used when a Get by ID message is sent.
        /// </summary>
        /// <value>The ID.</value>
        /// <remarks></remarks>
        public long ID { get; set; }

        /// <summary>
        /// Gets or sets the action.
        /// </summary>
        /// <value>The action.</value>
        /// <remarks></remarks>
        public MessageAction Action { get; set; }

        /// <summary>
        /// Gets or sets the custom action.
        /// </summary>
        /// <value>
        /// The custom action.
        /// </value>
        public string CustomAction { get; set; }

        /// <summary>
        /// Gets or sets the main parameter.
        /// </summary>
        /// <value>The main parameter.</value>
        /// <remarks></remarks>
        public TPar MainParameter { get; set; }
    }
}