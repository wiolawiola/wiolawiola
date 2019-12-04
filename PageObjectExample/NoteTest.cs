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
            var AdminPageWpisy = blogPage.AddNewNote();
            var exampleText = new ExampleWpis();
            var link = AdminPageWpisy.AddWpis(exampleText);
            var PublishNote = AdminPageWpisy.PublishWpis();
            PublishNote.LogOut();
            var PageResult = new NotePage(GetBrowser());
            PageResult.GoTo(link);

            Assert.True(PageResult.HasNote(exampleText));





        }


    }
}
