namespace Medical.Model.DTOs.Responses
{
    /// <summary>
    /// The command response class
    /// </summary>
    public class CommandResponse
    {
        /// <summary>
        /// Gets or sets the value of the success
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// Gets or sets the value of the message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandResponse"/> class
        /// </summary>
        /// <param name="success">The success</param>
        /// <param name="message">The message</param>
        public CommandResponse(bool success, string message = "")
        {
            Success = success;
            Message = message;
        }
        /// <summary>
        /// Marks the failed using the specified message
        /// </summary>
        /// <param name="message">The message</param>
        /// <returns>The command response</returns>
        public CommandResponse MarkFailed(string message = "")
        {
            Success = false;
            Message = message;
            return this;
        }

        /// <summary>
        /// Marks the succeded using the specified message
        /// </summary>
        /// <param name="message">The message</param>
        /// <returns>The command response</returns>
        public CommandResponse MarkSucceded(string message = "")
        {
            Success = true;
            Message = message;
            return this;
        }

        /// <summary>
        /// Faileds the message
        /// </summary>
        /// <param name="message">The message</param>
        /// <returns>The command response</returns>
        public static CommandResponse Failed(string message) => new(false, message);
        /// <summary>
        /// Succeededs the message
        /// </summary>
        /// <param name="message">The message</param>
        /// <returns>The command response</returns>
        public static CommandResponse Succeeded(string message) => new(true, message);
    }

    /// <summary>
    /// The command response class
    /// </summary>
    /// <seealso cref="CommandResponse"/>
    public class CommandResponse<T> : CommandResponse
       where T : class
    {
        /// <summary>
        /// Gets or sets the value of the result
        /// </summary>
        public T? Result { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandResponse"/> class
        /// </summary>
        /// <param name="success">The success</param>
        /// <param name="result">The result</param>
        /// <param name="message">The message</param>
        public CommandResponse(bool success = false, T? result = null, string message = "")
            : base(success, message)
        {
            Result = result;
        }
        /// <summary>
        /// Marks the failed using the specified message
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="result">The result</param>
        /// <returns>A command response of t</returns>
        public CommandResponse<T> MarkFailed(string message = "", T? result = null) 
        {
            base.MarkFailed(message);
            Result = result; 
            return this; 
        }

        /// <summary>
        /// Marks the succeded using the specified message
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="result">The result</param>
        /// <returns>A command response of t</returns>
        public CommandResponse<T> MarkSucceded(string message = "", T? result = null)
        {
            base.MarkSucceded(message);
            Result = result;
            return this;
        }

        /// <summary>
        /// Marks the succeded
        /// </summary>
        /// <returns>A command response of t</returns>
        public CommandResponse<T> MarkSucceded() 
        {
            base.MarkSucceded();
            return this;
        }

        /// <summary>
        /// Faileds the message
        /// </summary>
        /// <param name="message">The message</param>
        /// <returns>A command response of t</returns>
        public static new CommandResponse<T> Failed(string message = "") 
            => new(false, null, message);
        /// <summary>
        /// Succeededs the result
        /// </summary>
        /// <param name="result">The result</param>
        /// <param name="message">The message</param>
        /// <returns>A command response of t</returns>
        public static CommandResponse<T> Succeeded(T result, string message = "") 
            => new(true, result, message);
    }
}
