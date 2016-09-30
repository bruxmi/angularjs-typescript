using System;

namespace WebApiTypeScript.Core.Exceptions
{
	[Serializable]
    public class BaseAppException : Exception
    {
        public BaseAppException(string translationKey)
            : base(translationKey)
        {
        }

        public BaseAppException(string translationKey, Exception innerException) : base(translationKey, innerException)
        { }
    }
}