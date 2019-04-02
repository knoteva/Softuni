function main(code) {
    var tags = code.split("\n");
    tags.forEach(function(tag) {
        if (tag.trim().slice(0, 3) === "<a ") {
            var newTag = tag.replace("<a ", "[URL ").replace(">", "]").replace("</a>", "[/URL]");
            console.log(newTag);
        } else {
            console.log(tag);
        }
    });
}

main('<ul>\n <li>\n  <a href=http://softuni.bg>SoftUni</a>\n </li>\n</ul>');