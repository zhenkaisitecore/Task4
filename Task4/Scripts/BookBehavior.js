$(".lnkTake").click(function (e) {
    e.preventDefault();
    var reqObj = {id: this.parentElement.getAttribute("data-book-id")}
    $.ajax(
        {
            url: "Book/Take/",
            accepts: "application/json",
            contentType: "application/json; charset=utf-8",
            method: "POST",
            data: JSON.stringify(reqObj),
            async: false,
            beforeSend: () => alert("We are requesting the book..."),
            success: function (book) {
                var output = "This is the book you have requested.";
                output += "\nId: " + book.Id;
                output += "\nTitle: " + book.Title;
                output += "\nAuthor: " + book.Author;
                output += "\nCategory: " + book.Category;
                output += "\nPrice: RM " + book.Price;

                alert(output);
            }
        }
    );
});

$(".lnkReturn").click(function (e) {
    e.preventDefault();
    var reqObj = {id: this.parentElement.getAttribute("data-book-id")}
    $.ajax(
        {
            url: "Book/Return/",
            accepts: "application/json",
            contentType: "application/json; charset=utf-8",
            method: "POST",
            data: JSON.stringify(reqObj),
            async: false,
            beforeSend: () => alert("We are returning the book"),
            success: (result) => {
                var output = "";
                if (result.isReturned) {
                    output += "The book has been returned successfully!";
                    output += "\nReturned book: " + result.returned
                } else {
                    output += "The book is not returned...";
                }

                alert(output);
            }
        }
    );
});