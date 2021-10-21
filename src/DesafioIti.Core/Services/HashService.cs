using DesafioIti.Core.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DesafioIti.Core.Services
{
    public class HashService : IHashService
    {
        private const string _hashSpecialChars = @"!@#$%^&*()-+";

        /// <summary>
        /// Validate Hash Rules
        /// </summary>
        /// <param name="hashValue">Hash to valdiate</param>
        /// <returns>Indicates if hash is valid</returns>
        public ValueTask<bool> ValidateHash(string hashValue)
        {
            if (hashValue.Length < 9 ||
                !hashValue.Any(h => char.IsDigit(h)) ||
                !hashValue.Any(h => char.IsLower(h)) ||
                !hashValue.Any(h => char.IsUpper(h)) ||
                !_hashSpecialChars.Any(s => hashValue.Contains(s)) ||
                hashValue.Length != hashValue.ToCharArray().Distinct().Count() ||
                hashValue.Any(h => char.IsWhiteSpace(h)))
            {
                return new ValueTask<bool>(false);
            }

            return new ValueTask<bool>(true);

        }
    }
}
