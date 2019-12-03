using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace PageObjectExample
{
    public class CommentTests
    {
        [Fact]
        public void Can_add_new_comment_to_latest_note()
        {
            var blogStartPage = MainPage.Open();
          var note = blogStartPage.NavigateToNewesNote();
            var exampleComment = new ExampleComment();
            var noteWithComment = note.AddComent(exampleComment);

            Assert.True(noteWithComment.Has(exampleComment));
        }
    }
}
