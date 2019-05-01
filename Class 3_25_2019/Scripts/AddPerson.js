$(() => {
	let x = 1;
	$("#AddPerson").on('click', function () {
		console.log("`Hi`")
		$("#personform").append(`<div class="row">
				<div class="col-md-4">
					<input type="text" placeholder="First Name" name="people[${x}].firstname" class="form-control" />
				</div>
				<div class="col-md-4">
					<input type="text" placeholder="Last Name" name="people[${x}].lastname" class="form-control" />
				</div>
				<div class="col-md-4">
					<input type="text" placeholder="Age" name="people[${x}].age" class="form-control" />
				</div>
			</div>`);
		x++;
	});
});