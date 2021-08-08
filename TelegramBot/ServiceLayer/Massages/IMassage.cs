using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace ServiceLayer
{
    public interface IMassage
    {
        string Text { get; }
    }
}