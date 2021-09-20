//                                                                                   latihan css starwars (main data api) cara 1

//$.ajax({
//    url: 'https://swapi.dev/api/people',
//}).done(result => {
//    console.log(result.results);
//    let item = "";
//    $.each(result.results, function (key, val) {
//        item += `<tr>
//                <td>${key + 1}</td>
//                <td>${val.name}</td>
//                <td>
//                    <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModalLong${key + 1}">Detail</button>
//                    <div class="modal fade" id="exampleModalLong${key + 1}" tabindex="-1" role="dialog" aria-labelledby="exampleModalLong${key + 1}Label" aria-hidden="true">
//                        <div class="modal-dialog" role="document">
//                            <div class="modal-content">
//                                <div class="modal-header">
//                                    <h5 class="modal-title" id="exampleModalLong${key + 1}Label">Detail of ${val.name}</h5>
//                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
//                                        <span aria-hidden="true">&times;</span>
//                                    </button>
//                                </div>
//                                <div class="modal-body">
//                                    <li>Name : ${val.name}</li>
//                                    <li>Gender : ${val.gender}</li>
//                                    <li>Birth year : ${val.birth_year}</li>
//                                    <li>Height : ${val.height}</li>
//                                    <li>Mass : ${val.mass}</li>
//                                    <li>Hair Color : ${val.hair_color}</li>
//                                    <li>Eye Color : ${val.eye_color}</li>
//                                    <li>Skin Color : ${val.skin_color}</li>
//                                </div>
//                                <div class="modal-footer">
//                                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
//                                    <button type="button" class="btn btn-primary">Save changes</button>
//                                </div>
//                            </div>
//                        </div>
//                    </div>
//                </td>
//                </tr>`;
//    });
//    $("#starwars").html(item);
//}).fail(result => {
//    console.log(result);
//});

//                                                                                latihan css starwars (main data api) cara 2

//$(document).ready(() => {
//    $.ajax({
//        url: 'https://swapi.dev/api/people',
//    }).done(result => {

//        console.log(result.results);
//        let items = "";


//        $.each(result.results, (key, val) => {
//            items += `<tr class="item${key + 1}">
//                    <td>${key + 1}</td>
//                    <td>${val.name}</td>
//                    <td>
//                        <button class="item-detail btn btn-primary"
//                                data-toggle="modal"
//                                data-target="#exampleModalLong"
//                                onClick="detailItem('${val.url}')">Detail</button>
//                        <button class="btn btn-danger" onClick="removeItem('item${key + 1}')">Hapus</button>
//                    </td>
//                  </tr>`
//        });
//        $('#starwars').html(items);
//    });
//});

//const removeItem = (id) => {
//    $(`tr.${id}`).remove();
//}

//const detailItem = (url) => {
//    $.ajax({
//        url: url
//    }).done(result => {
//        console.log(result);
//        let detailText = `<ul>
//                            <li>Name : ${result.name}</li>
//                            <li>Gender : ${result.gender}</li>
//                            <li>Birth year : ${result.birth_year}</li>
//                            <li>Height : ${result.height}</li>
//                            <li>Mass : ${result.mass}</li>
//                            <li>Hair Color : ${result.hair_color}</li>
//                            <li>Eye Color : ${result.eye_color}</li>
//                            <li>Skin Color : ${result.skin_color}</li>
//                          </ul>`;
//        $('.modal-body').html(detailText);
//        $('h5.modal-title').html(`Character Detail: ${result.name}`);
//    }).fail(result => {
//        console.log(result);
//    });
//}

//                                                                             latihan api pokemon

//$(document).ready(() => {
//    $.ajax({
//        url: 'https://pokeapi.co/api/v2/pokemon?limit=2000',
//    }).done(result => {

//        console.log(result.results);
//        let items = "";


//        $.each(result.results, (key, val) => {
//            items += `<tr class="item${key + 1}">
//                    <td>${key + 1}</td>
//                    <td>${val.name}</td>
//                    <td>
//                        <button class="item-detail btn btn-primary"
//                                data-toggle="modal"
//                                data-target="#exampleModalCenter"
//                                onClick="detailItem('${val.url}')">Detail</button>
//                        <button class="btn btn-danger" onClick="removeItem('item${key + 1}')">Hapus</button>
//                    </td>
//                  </tr>`
//        });
//        $('#pokemon').html(items);
//    });
//});

//const removeItem = (id) => {
//    $(`tr.${id}`).remove();
//}

//const detailItem = (url) => {
//    $.ajax({
//        url: url
//    }).done(result => {     
//        let abilities = ""
//        $.each(result.abilities, (key, val) => {
//            abilities += val.ability.name;
//            if (key != Object.keys(result.abilities).length-1) {
//                abilities += ", "
//            }
//        });
//        let moves = ""
//        for (let i = 0; i < 4; i++){
//            moves += result.moves[i].move.name
//            if (i< 3) {
//                moves += ", "
//            }
//        }
//        let types = []
//        $.each(result.types, (key, val) => {
//            types[key] = val.type.name;
//        });
//        console.log(result.sprites.other['official-artwork'].front_default)
//        let pokemonimg = `<img src="${result.sprites.other['official-artwork'].front_default}" alt="Pokemon Img">`
//        let detailText = `<ul class="detail">
//                            <li><b>Name :</b><div>${result.name}</div></li>
//                            <li><b>Ability :</b><div>${abilities}</div></li>
//                            <li><b>Move :</b><div>${moves}</div></li>
//                          </ul>`;
//        let typesbadge = ""
//        $.each(types, (key, val) => {
//            typesbadge += type_badge(val);
//        });
//        let typesdetail = `<ul class="types">
//                            <b>TYPES : </b>
//                            ${typesbadge}
//                           </ul>`
//        $('.detail').html(detailText);
//        $('.types').html(typesdetail);
//        $('.pokeimg').html(pokemonimg);
//        $('h5.modal-title').html(`Detail of ${result.name}`);
//    }).fail(result => {
//        console.log(result);
//    });
//}

//function type_badge(types) {
//    if (types === "normal") {
//        return `<div class="col-border"><span class="badge badge-pill badge-normal">Normal</span></div>`
//    } else if (types === "fire") {
//        return `<div class="col-border"><span class="badge badge-pill badge-fire">Fire</span></div>`
//    } else if (types === "water") {
//        return `<div class="col-border"><span class="badge badge-pill badge-water">Water</span></div>`
//    } else if (types === "grass") {
//        return `<div class="col-border"><span class="badge badge-pill badge-grass">Grass</span></div>`
//    } else if (types === "electric") {
//        return `<div class="col-border"><span class="badge badge-pill badge-electric">Electric</span></div>`
//    } else if (types === "ice") {
//        return `<div class="col-border"><span class="badge badge-pill badge-ice">Ice</span></div>`
//    } else if (types === "fighting") {
//        return `<div class="col-border"><span class="badge badge-pill badge-fighting">Fighting</span></div>`
//    } else if (types === "poison") {
//        return `<div class="col-border"><span class="badge badge-pill badge-poison">Poison</span></div>`
//    } else if (types === "ground") {
//        return `<div class="col-border"><span class="badge badge-pill badge-ground">Ground</span></div>`
//    } else if (types === "flying") {
//        return `<div class="col-border"><span class="badge badge-pill badge-flying">Flying</span></div>`
//    } else if (types === "psychic") {
//        return `<div class="col-border"><span class="badge badge-pill badge-psychic">Psychic</span></div>`
//    } else if (types === "bug") {
//        return `<div class="col-border"><span class="badge badge-pill badge-bug">Bug</span></div>`
//    } else if (types === "rock") {
//        return `<div class="col-border"><span class="badge badge-pill badge-rock">Rock</span></div>`
//    } else if (types === "ghost") {
//        return `<div class="col-border"><span class="badge badge-pill badge-ghost">Ghost</span></div>`
//    } else if (types === "dark") {
//        return `<div class="col-border"><span class="badge badge-pill badge-dark">Dark</span></div>`
//    } else if (types === "dragon") {
//        return `<div class="col-border"><span class="badge badge-pill badge-dragon">Dragon</span></div>`
//    } else if (types === "steel") {
//        return `<div class="col-border"><span class="badge badge-pill badge-steel">Steel</span></div>`
//    } else if (types === "fairy") {
//        return `<div class="col-border"><span class="badge badge-pill badge-fairy">Fairy</span></div>`
//    }
//}

$.ajax({
    url: "https://localhost:44300/api/persons/GetPersonVM"
}).done((result) => {
    var text = "";
    $.each(result.data, function (key, val) {
        console.log(val);
    });
}).fail((result) => {
    console.log(result);
});

let table = $('#tablee').DataTable({
    dom: 'Bfrtip',
    buttons: [
        {
            extend: 'excelHtml5',
            exportOptions: {
                columns: [1, 2, 3]
            },
            bom: true
        },
        {
            extend: 'pdfHtml5',
            exportOptions: {
                columns: [1, 2, 3]
            },
            bom: true
        },
        {
            extend: 'csvHtml5',
            exportOptions: {
                columns: [1, 2, 3]
            },
            bom: true
        },
        {
            extend: 'print',
            exportOptions: {
                columns: [1, 2, 3]
            },
            bom: true
        },
    ],
    "filter": true,
    "ajax": {
        "url": "https://localhost:44300/API/Persons/GetPersonVM",
        "datatype": "json",
        "dataSrc": "data"
    },
    "columns": [
        {
            "data": null,
            "sortable": false,
            "orderable": false,
            "targets": 0,
            render: function (data, type, row, meta) {
                return meta.row + meta.settings._iDisplayStart + 1;
            }
        },
        {
            "data": "nik"
        },
        {
            "data": null,
            "render": function (data, type, row) {

                return row["fullName"];
            },
            "autoWidth": true
        },
        {
            "data": null,
            "render": function (data, type, row) {
                const usingsplit = data.phone.split('');
                if (usingsplit[0] === "0") {
                    usingsplit[0] = "+62";
                }
                data.phone = usingsplit.join("");
                return row["phone"];
            },
            "autoWidth": true
        },
        {
            "data": null,
            "sortable": false,
            "orderable": false,
            "render": function (data, type, row) {
                const dataRow = `<button
                                    type="button"
                                    data-toggle="modal"
                                    data-target="#exampleModal"
                                    onClick="detailItem('${row["nik"]}')"
                                    class="item-detail btn btn-primary btn-sm">Detail</button>
                                    <button
                                    type="button"
                                    onClick="deletePerson('${row["nik"]}')"
                                    class="item-detail btn btn-danger btn-sm">Delete</button>`
                return dataRow;
            }
        }
    ]
});

const detailItem = (nik) => {
    $.ajax({
        url: 'https://localhost:44300/API/persons/getnik/' + nik
    }).done(result => {
        console.log(result)
        let gender =""
        if (result.data[0].gender === 0) {
            gender = "Male"
        } else {
            gender = "Female"
        }
        let detailText = `<ul class="detail">
                            <li><b>NIK          : </b>${result.data[0].nik}</li>
                            <li><b>Name         : </b>${result.data[0].fullName}</li>
                            <li><b>Gender       : </b>${gender}</li>
                            <li><b>Email        : </b>${result.data[0].email}</li>
                            <li><b>Phone        : </b>${result.data[0].phone}</li>
                            <li><b>Birth Date   : </b>${result.data[0].birthDate}</li>
                            <li><b>Salary       : </b>Rp. ${moneyMaker(result.data[0].salary)}</li>
                            <li><b>Degree       : </b>${result.data[0].degree}</li>
                            <li><b>GPA          : </b>${result.data[0].gpa}</li>
                          </ul>`;
        $('.detail-body').html(detailText);
        $('h5.detail-title').html(`More Information of ${result.data[0].fullName}`);
    }).fail(result => {
        console.log(result);
    });
}

function moneyMaker(bilangan)
{
    var number_string = bilangan.toString(),
        sisa = number_string.length % 3,
        rupiah = number_string.substr(0, sisa),
        ribuan = number_string.substr(sisa).match(/\d{3}/g);

    if (ribuan) {
        separator = sisa ? '.' : '';
        rupiah += separator + ribuan.join('.');
    }
    return rupiah;
}

$("#submitdata").click(function (event) {
    event.preventDefault();
    var obj_register = new Object();
    obj_register.NIK = $("#validationCustom03").val();
    obj_register.fullName = $("#validationCustom01").val();
    obj_register.Phone = $("#notelp").val();
    obj_register.birthDate = $("#start").val(); 
    obj_register.email = $("#validationCustom04").val();
    obj_register.gender = $('#inputGender').val();
    obj_register.password = $("#inputpassword").val();
    obj_register.degree = $("#validationCustom05").val();
    obj_register.gpa = $("#validationCustom06").val();

    if ($("#validationgaji").val() == "") {
        document.getElementById("validationgaji").className = "form-control is-invalid";
        $("#msgSalary").html("Salary tidak boleh kosong");
    } else {
        document.getElementById("validationgaji").className = "form-control is-valid";
        obj_register.salary = $("#validationgaji").val();
    }

    console.log(JSON.stringify(obj_register));

    $.ajax({
        url: "https://localhost:44300/API/Persons/InsertPerson",
        type: "POST",
        dataType: 'json',
        contentType: 'application/json',
        crossDomain: true,
        data: JSON.stringify(obj_register),
        success: function (data) {
            $('#register').modal('hide')
            Swal.fire({
                title: 'Success Inserting Data!',
                text: 'Press Any Button to Continue',
                icon: 'success',
                confirmButtonText: 'Okay'
            })
            table.ajax.reload();
        },
        error: function (xhr, status, error)
        {
            console.log(xhr.responseJSON.errors);
            if (xhr.responseJSON.errors != undefined) {
                checkValid(xhr.responseJSON.errors.NIK, "validationCustom03", "#msgNIK");
                checkValid(xhr.responseJSON.errors.Degree, "validationCustom05", "#msgDegree");
                checkValid(xhr.responseJSON.errors.Email, "validationCustom04", "#msgEmail");
                checkValid(xhr.responseJSON.errors.FullName, "validationCustom01", "#msgFN");
                checkValid(xhr.responseJSON.errors.GPA, "validationCustom06", "#msgGPA");
                checkValid(xhr.responseJSON.errors.Password, "inputpassword", "#msgPW");
                checkValid(xhr.responseJSON.errors.Phone, "notelp", "#msgPhone");
            }

        }
    })
});

function deletePerson(NIK) {
    console.log(NIK)
    Swal.fire({
        title: 'Are you sure you want to delete this?',
        showCancelButton: true,
        confirmButtonText: 'Yes',
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: 'https://localhost:44300/API/persons/' + NIK,
                type: "DELETE",
                success: function (data) {
                    Swal.fire({
                        title: 'Success Delete Data!',
                        text: 'Press Any Button to Continue',
                        icon: 'success',
                        confirmButtonText: 'Okay'
                    })
                    table.ajax.reload();
                },
                error: function (xhr, status, error) {
                    Swal.fire({
                        icon: 'error',
                        title: 'Oops...',
                        text: 'Something went wrong!',
                        footer: '<a href="">Why do I have this issue?</a>'
                    })
                    }
                })
            }
        })
}

function checkValid(errMsg, eleById, eleMsg) {
    if (errMsg != undefined) {
        document.getElementById(`${eleById}`).className = "form-control is-invalid";
        $(`${eleMsg}`).html(`${errMsg}`);
    } else {
        document.getElementById(`${elebyId}`).className = "form-control is-valid";
    }
}

$(document).ready(() => {
    $.ajax({
        url: 'https://localhost:44300/api/persons/GetPersonVM',
        type: "GET"
    }).done((result) => {
        console.log(result);
        var female = result.data.filter(data => data.gender === 1).length;
        var male = result.data.filter(data => data.gender === 0).length;
        console.log(male);
        console.log(female);
        var options = {
            series: [{
                name: 'Male',
                data: [male]
            }, {
                name: 'Female',
                data: [female]
            }],
            chart: {
                type: 'bar',
                height: 350
            },
            plotOptions: {
                bar: {
                    horizontal: false,
                    columnWidth: '55%',
                    endingShape: 'rounded'
                },
            },
            dataLabels: {
                enabled: false
            },
            stroke: {
                show: true,
                width: 2,
                colors: ['transparent']
            },
            xaxis: {
                categories: ['Male','Female'],
            },
            yaxis: {
                title: {
                    text: 'Count'
                }
            },
            fill: {
                opacity: 1
            },
            tooltip: {
                y: {
                    formatter: function (val) {
                        return val
                    }
                }
            }
        };

        var chart = new ApexCharts(document.querySelector("#chart1"), options);
        chart.render();
    })
})

$(document).ready(() => {
    $.ajax({
        url: 'https://localhost:44300/api/persons/GetPersonVM',
        type: "GET"
    }).done((result) => {
        console.log(result);
        var female = result.data.filter(data => data.gender === 1).length;
        var male = result.data.filter(data => data.gender === 0).length;
        console.log(male);
        console.log(female);
        var options = {
            series: [male,female],
            chart: {
                width: 380,
                type: 'pie',
            },
            labels: ['Male', 'Female'],
            responsive: [{
                breakpoint: 480,
                options: {
                    chart: {
                        width: 200
                    },
                    legend: {
                        position: 'bottom'
                    }
                }
            }]
        };

        var chart = new ApexCharts(document.querySelector("#chart2"), options);
        chart.render();

    })
})

$(document).ready(() => {
    $.ajax({
        url: 'https://localhost:44300/api/persons/GetPersonVM',
        type: "GET"
    }).done((result) => {
        console.log(result);
        var female = result.data.filter(data => data.gender === 1).length;
        var male = result.data.filter(data => data.gender === 0).length;
        console.log(male);
        console.log(female);
        var options = {
            series: [male,female],
            chart: {
                height: 390,
                type: 'radialBar',
            },
            plotOptions: {
                radialBar: {
                    offsetY: 0,
                    startAngle: 0,
                    endAngle: 270,
                    hollow: {
                        margin: 5,
                        size: '30%',
                        background: 'transparent',
                        image: undefined,
                    },
                    dataLabels: {
                        name: {
                            show: false,
                        },
                        value: {
                            show: false,
                        }
                    }
                }
            },
            colors: ['#1ab7ea', '#0084ff'],
            labels: ['Male', 'Female'],
            legend: {
                show: true,
                floating: true,
                fontSize: '16px',
                position: 'left',
                offsetX: 160,
                offsetY: 15,
                labels: {
                    useSeriesColors: true,
                },
                markers: {
                    size: 0
                },
                formatter: function (seriesName, opts) {
                    return seriesName + ":  " + opts.w.globals.series[opts.seriesIndex]
                },
                itemMargin: {
                    vertical: 3
                }
            },
            responsive: [{
                breakpoint: 480,
                options: {
                    legend: {
                        show: false
                    }
                }
            }]
        };

        var chart = new ApexCharts(document.querySelector("#chart3"), options);
        chart.render();

    })
})