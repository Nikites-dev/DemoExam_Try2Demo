using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace Lopushok.Data
{
    public partial class Product
    {

        public string ProductTitle => $"{ProductType.Name} | {Name}";
        public decimal Price => ProductMaterial.Sum(x => x.Material.Cost * x.MaterialCount);
        public string MaterialList => GetMaterials();

        private string GetMaterials()
        {
            var str = "";

            foreach (var item in ProductMaterial)
            {
                str += item.Material.Name + ", ";
            }

            return str;
        }

        public ImageSource ImageSource
        {
            get
            {
                var bitmap = new BitmapImage();
                byte[] bytes;

                if (Image == null || Image == "" || Image == "нет" || Image == "не указано")
                {
                    bytes = File.ReadAllBytes(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName +
                                              $"\\Images\\picture.png");
                }
                else
                {
                    bytes = File.ReadAllBytes(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName +
                                              $"\\Images{Image}");
                }

                var ms = new MemoryStream(bytes);


                bitmap.BeginInit();
                bitmap.StreamSource = ms;
                bitmap.EndInit();
                return bitmap;
            }
        }
    }
}
