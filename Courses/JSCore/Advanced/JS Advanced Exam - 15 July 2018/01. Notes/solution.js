function addSticker(){
	let title = $('.title').val();
	let content = $('.content').val();
	   // console.log(title);
	   // console.log(content)
	   if(title !=='' && content !== ''){
		   let li = $('<li class = note-content>');
		   let row = li
		   .append($('<a class = button>').text('x')).on('click', () => li.remove())
		   .append($('<h2>').text(`${title}`))
		   .append($('<hr>'))
		   .append($('<p>').text(`${content}`))
		   $('.title').val('');
		   $('.content').val('');
		   $('#sticker-list').append(row)
		   
		//    $(".button").click(function(){
		// 	   $(row).remove();
		//    });
   
	   }
   }