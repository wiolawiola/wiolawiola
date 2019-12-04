using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PageObjectExample
{
    public class NoteTest : BaseTest
    {
      

        [Fact]
        public void Can_publish_new_note()
        {
            var blogStartPage = LoginPage.Open(GetBrowser());
            var blogPage = blogStartPage.EnterUserDataAndLogin();
            var AdminPage = blogPage.AddNote();
            
           

        }


    }
}
