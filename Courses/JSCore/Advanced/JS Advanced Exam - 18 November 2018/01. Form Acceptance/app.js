function acceptance() {
	let shippingCompany = $('[name="shippingCompany"]');
	let productName = $('[name=productName]');
	let productQuantity = $('[name=productQuantity]');
	let productScrape = $('[name=productScrape]')
	let regex=/^[0-9]+$/;
	let quant = productQuantity.val() - productScrape.val()
	if(shippingCompany.val().length !=0 && productName.val().length !=0 && productScrape.val().match(regex) && productQuantity.val().match(regex) 
	&& quant > 0){
		//console.log(quant)
		//[{companyName}] {productName} - {productQuantity} pieces {outOfStockButton}
		let div = $('<div>');

		let row = div
			.append($('<p>').text(`[${shippingCompany.val()}] ${productName.val()} - ${quant} pieces` ))
			.append($('<button type="button" id ="removeB">').text('Out of stock')).on('click', () => div.remove());
			$('#warehouse').append(row)
			
			shippingCompany.val('');
			productName.val('');
			productQuantity.val('');
			productScrape.val('');
		// 	$("#removeB").click(function(){
		// 		$("#removeId").remove();
		
		// });
	}  
}