function successAjax(message, error) {
    if (error == 'true') {
        showAlert(`${message}`, 'alert-danger')
    }
    else {
        showAlert(message, 'alert-success')
        $('#mdlAddSkill').modal('hide');
    }
}

function getSkills() {
    return $.ajax({
        url: "/Home/GetSkills/",
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            if (data) {
                data.forEach(el => {

                    //TODO: Metodo
                    //let small = document.createElement('small')
                    //small.innerText = element.tag

                    //let div = document.createElement('div')
                    //div.classList.add('mb-3')
                    //div.style.height = '5px'

                    //let input = document.createElement('input')
                    //input.type = 'range'
                    //input.id = element.id

                    const creaElemento = (element) => {
                        return `<small>${element.tag}</small>
                        <div class="mb-3" style="height: 5px">
                            <input class="col-10" type="range" id="${element.id}" name="${element.id}" min="10" max="100" value="${element.tag}">
                            <button data-value="${element.id}" class="btn btn-outline-danger btn-circle deletable"><i class="fa fa-times"></i></button>
                        </div>`}

                    $('#divSectionSkill')
                        .append(creaElemento(el))
                });

                $('.deletable').click(function (e) { addRemoveListener(e) });
            }
            else {
                $('#divSectionSkill')
                    .append('<h6 class="d-flex align-items-center mb-3">Inserisci le tue 3 migliori <i class="material-icons text-info ml-2">Skill</i> </h6>')
            }
        },
        beforeSend: function () {
            appendSpinner('divSectionSkill')
            $('#spinner').removeClass('d-none')
        },
        complete: function () {
            appendSpinner('divSectionSkill')
            $('#spinner').addClass('d-none')
        }
    });
}

function appendSpinner(idToAppendElement) {

    let spinner = $('#spinner')
    $(`#${idToAppendElement}`).append(spinner)
}

