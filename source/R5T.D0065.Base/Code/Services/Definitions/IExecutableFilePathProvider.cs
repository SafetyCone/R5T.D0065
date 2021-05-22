using System;
using System.Threading.Tasks;


namespace R5T.D0065
{
    public interface IExecutableFilePathProvider
    {
        Task<string> GetExecutableFilePath();
    }
}
