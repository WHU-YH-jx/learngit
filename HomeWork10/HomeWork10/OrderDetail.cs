using System;
using System.ComponentModel.DataAnnotations;

namespace HomeWork10
{
    public class OrderDetail {
        [Key]
        public string Id { get; set; }
        public string GoodsName { get; set; }
        public double GoodPrice { get; set; }
        public int GoodsNumber { get; set; }

        public OrderDetail() {
          Id = Guid.NewGuid().ToString();
        }

        public OrderDetail(string id, string name, double price, int number) {
            Id = id;
            GoodsName = name;
            GoodPrice = price;
            GoodsNumber = number;
        }
    }
}