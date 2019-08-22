using System.Threading.Tasks;

namespace MenuLogic.Domain
{
    public struct ItemLogicModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int ShopID { get; set; }

        public int Price { get; set; }
    }
}
