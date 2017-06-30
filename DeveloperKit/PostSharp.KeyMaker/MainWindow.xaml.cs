using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PostSharp.Sdk.Extensibility.Licensing;

/***
 * title:PostSharp 注册机
 * date:2017-06-30
 * author:YUXiaoWei
 * refer:http://www.th7.cn/Program/net/201409/274209.shtml
 ***/
namespace PostSharp.KeyMaker
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //DSACryptoServiceProvider dsac = new DSACryptoServiceProvider();
            //string strPublic = dsac.ToXmlString(false); //公钥
            //string strPrivate = dsac.ToXmlString(true); //私钥
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            string privateKey = "<DSAKeyValue><P>jiPujIi7gSoU/Q7UbOXevaFA4v4J9g1+VRza1LKq4bap/omDVDtrZc8USbGZZY3+RnLhvO3mqASe0P+1y52bOc6NRHunWAjN5RnjFrPgxtrdyuZlXccNnqle/frslig25YjiweFeRxz23GaUsfWXBZM/rv/mRaa98NLiwUqQKEU=</P><Q>k1Mp8hT+l4dDijTIDO9D6PF+tjE=</Q><G>bTjcY8M0RGp4FIvmIOY9OmPHVvY6U2QrWN/vXdGqWO0tdpveK2y9reFrFvhHQikAac2t/+Gwy7IBYovCdvWlAJWnDSVRZ0B4JNkasb+06ByoHs+qyqB85qGey2sY3zV0ylaOQP66CroCA0D+Pe0cZojHuUMT67s6o9pZAdLVnW0=</G><Y>K1KZ2uRXJYuE6Y+XFz75MZtHjGCM3wOjy7nleqnfcu3ACO4goLG1KpVVag0PfNtlJkl3TLsIkUIqPNnXZ3Tw8p8ZSp4Uij6ak2wMrXnrlUYliqQYVy2yeqBqZ2EjpsGPTPkhYfhNbJZRG4qGgfKfuqLIL/ywm3UORKjmHjCvBv8=</Y><Seed>RsRHcfxn1pFxS45n7X3rK5TJFCE=</Seed><PgenCounter>Abs=</PgenCounter><X>fYbwUNFjMtYlS0oqPg2zmsjNEWQ=</X></DSAKeyValue>";
            License lic = License.Create(LicensedProduct.PostSharp30);
            lic.LicenseGuid = Guid.NewGuid();
            lic.LicenseType = (byte)LicenseType.Commercial;
            lic.Product = LicensedProduct.PostSharp30;
            lic.Sign(1, privateKey);
            string sn = lic.Serialize(); //最终注册码
            this.txtKey.Text = sn;
        }
    }
}
