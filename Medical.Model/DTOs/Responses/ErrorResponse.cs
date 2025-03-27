using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Model.DTOs.Responses
{
    public class ErrorResponse
    {
        /// <summary>
        /// Gets or sets the value of the success
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// Gets or sets the value of the message
        /// </summary>
        public string Message { get; set; }

    }
}
