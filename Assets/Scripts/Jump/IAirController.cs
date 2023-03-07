
namespace Jomp
{
    public interface IAirController
    {
        public bool Jumping { set; get; }
        public bool IsFalling { set; get; }
        public bool IsGrounding { set; get; }
    }
}

