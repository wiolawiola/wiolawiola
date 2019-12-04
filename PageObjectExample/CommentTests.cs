using Xunit;


namespace PageObjectExample
{
    public class CommentTests : BaseTest
    {
        
        [Fact]
        public void Can_add_new_comment_to_latest_note()
        {
            var blogStartPage = MainPage.Open(GetBrowser());
            var notePage = blogStartPage.NavigateToNewesNote();
            var exampleComment = new ExampleComment();
            var noteWithComment = notePage.AddComent(exampleComment);

            Assert.True(noteWithComment.Has(exampleComment));
        }


    }
}
