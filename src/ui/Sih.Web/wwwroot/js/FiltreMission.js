
//Insert default item "Select" in dropdownlist on load
//$(document).ready(function () {
//    var items = "<option value='0'> </option>";
//    $("#MissionDDL").html(items);
//});

//Bind MissionDiplomatique dropdownlist
$("#TypeMissionDDL").change(function () {

    var typeMissionId = $("#TypeMissionDDL").val();

    var url = "/Setting/CascadingDDL/FiltreMission";

    $.getJSON(url, { idTypeMission: typeMissionId }, function (data) {
        var item = "";
        $("#MissionDDL").empty();
        $.each(data, function (i, missionDiplomatique) {
            item += '<option value="' + missionDiplomatique.value + '">' + missionDiplomatique.text + '</option>'
        });
        $("#MissionDDL").html(item);
    });
});

//Bind MissionDiplomatique dropdownlist
$("#TypeEquipementDDL").change(function () {

    var typeEquipementId = $("#TypeEquipementDDL").val();

    var url = "/Setting/CascadingDDL/FiltreEquipement";

    $.getJSON(url, { idTypeEquipement: typeEquipementId }, function (data) {
        var item = "";
        $("#EquipementDDL").empty();
        $.each(data, function (i, Equipement) {
            item += '<option value="' + Equipement.value + '">' + Equipement.text + '</option>'
        });
        $("#EquipementDDL").html(item);
    });
});
