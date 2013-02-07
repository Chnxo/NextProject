using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcContrib.CommandProcessor;
using MvcContrib.CommandProcessor.Commands;

namespace NextProjectMVC.Core
{
    /// <summary>
    ///
    /// </summary>
    /// <remarks></remarks>
    public interface IBus
    {
        /// <summary>
        /// Sends the specified message.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        Result Send<T>(T message);
    }

    public class Result : ReturnValue
    {
        /// <summary>
        /// Contains the read-only value for an unsuccessful processing of a message.
        /// </summary>
        public static readonly Result Failure = new Result(false);

        /// <summary>
        /// Initializes a new instance of the <see cref="Result"/> class.
        /// </summary>
        /// <param name="succes">if set to <c>true</c> [succes].</param>
        /// <remarks></remarks>
        public Result(bool succes = true)
        {
            Success = succes;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Result"/> is success.
        /// </summary>
        /// <value><c>true</c> if success; otherwise, <c>false</c>.</value>
        /// <remarks></remarks>
        public bool Success { get; set; }
    }

    /// <summary>
    ///
    /// </summary>
    /// <remarks></remarks>
    public class Bus : IBus
    {
        /// <summary>
        /// Sends the specified message.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public Result Send<T>(T message)
        {
            //   var handler = DependencyResolver.Current.GetService<IMessageHandler<T>>();
            
            var handler = DependencyResolver.Current.GetService<Command<T>>();
#if DEBUG
            if (handler == null)
            {
                throw new InvalidOperationException(string.Format("The command handler for type {0} does not exist or was not registered.", typeof(T)));
            }
#endif
            return (Result)handler.Execute(message);
        }
    }
}