function realEstateAgency () {
	let regButton = $('[name=regOffer]')
	let findButton = $('[name=findOffer]')
	let apartmentRent = $('[name=apartmentRent]')//number>0
	let apartmentType = $('[name=apartmentType]')//not empty, <>":"
	let agencyCommission = $('[name=agencyCommission]')//0<=number<=100
	
	let familyBudget = $('[name=familyBudget]')//number>0
	let familyApartmentType = $('[name=familyApartmentType]')//not empty
	let familyName = $('[name=familyName]')//not empty
	let  price = 0
	let name = ''
	
	
	let regex=/^[0-9]+$/;

	$(regButton).click(function(){
		if(apartmentType.val().length !=0 && apartmentType.val().indexOf(":") == -1 && apartmentRent.val().match(regex)
		&& apartmentRent.val() > 0 && agencyCommission.val().match(regex) && agencyCommission.val() >= 0
		&& agencyCommission.val() <= 100){
			let price = +apartmentRent.val()*+agencyCommission.val()/100 + +apartmentRent.val();
			let row = ($('<div class="apartment">'))
			.append($('<p id="p1">').text(`Rent: ${apartmentRent.val()}`))
			.append($('<p id="p2">').text(`Type: ${apartmentType.val()}`))
			.append($('<p id="p3">').text(`Commission: ${agencyCommission.val()}`))
			//.append($('<p>').text(`Price: ${price}`))
			$('#building').append(row)
			//text(`Rent: ${apartmentRent.val()}Type: ${apartmentType.val()}\n Commission: ${agencyCommission.val()}` )
			
			$('#message').text('Your offer was created successfully.');
			
			//console.log(price)
		} else {
			$('#message').text('Your offer registration went wrong, try again.');
		}
		price = +apartmentRent.val()*+agencyCommission.val()/100 + +apartmentRent.val();
		apartmentRent.val('');
		apartmentType.val('');
		agencyCommission.val('');
	
		$(findButton).click(function(){
			
			if(familyBudget.val().match(regex) && familyBudget.val() > 0 && familyApartmentType.val().length !=0 
			&& familyName.val().length !=0) {
				let i = 0
				
					
				
				$("#building").find('[class="apartment"]').each(build=> {
					if("Type: " + familyApartmentType.val() == $("#building").find('[class="apartment"]')[build].childNodes[1].innerHTML
					&& familyBudget.val() >= price){
						$('#h1').text(`Agency profit: ${price} lv.`)
						$('#p3').remove();
					$('#p1').text(`${familyName.val()} `);
					$('#p2').text(`live here now`)
					$('.apartment').append($('<button class="move">').text('MoveOut'));
					$('.apartment').css({'border': '2px solid red'});
						$('#message').text('Enjoy your new home! :))');
					
					} else{
						
						$('#message').text('We were unable to find you a home, so sorry :(');
					}

					
					familyBudget.val('');
					familyApartmentType.val('');
					name = familyName.val();
					familyName.val('');
					
				});
				$('.move').click(function(){
					$('.apartment').remove();
					$('#message').text(`They had found cockroaches in ${name}\'s apartment`);
				});
					
			}
			
		});
		
	});
	
}