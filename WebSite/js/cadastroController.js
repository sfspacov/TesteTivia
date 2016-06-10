angular.module('cadastro', ["ui.bootstrap"])
  .filter('startFrom', function () {
        return function (data, start) {
            start = 0 + start;
            if (data != null && data.slice != null)
                return data.slice(start);
            return null;
        }
    })
  .controller('CadastroController', function ($scope, $http) {
      $scope.pageSize = 3;
      $scope.currentPage = 1;
      $scope.Veiculo = {
          Model: {},
          Cancelar: function () {
              $scope.Veiculo.Model = {};
          },
          Deletar: function (id) {

              $('#modalConfirm').modal({
                  show: true,
                  backdrop: 'static'
              });

              $scope.Confirm = function () {
                  var sucesso = function () {
                      $("#loading").modal("hide");
                      carregarVeiculos();
                  };

                  var erro = function () {
                      $("#loading").modal("hide");
                  };

                  $.ajax({
                      type: "DELETE",
                      url: "http://localhost:54698/api/Veiculos/" + id,
                      success: sucesso,
                      error: erro
                  });
                  $('#modalConfirm').modal("hide");
              };
          },
          Editar: function (item) {
              $('html, body').animate({ scrollTop: 0 }, 'slow');
              $scope.Veiculo.Model = $.extend({}, item);
              $scope.Editar = true;
          },
          Salvar: function () {
              SaveOrEdit($scope.Editar);
              $scope.Editar = false;
          },
      };
      $scope.ValidarNumero = function (model, propriedade) {
          for (var key in model) {

              if (key.toUpperCase() === propriedade.toUpperCase()) {

                  if (model[key] == undefined) {
                      model[key] = "";
                  }
                  else if (parseFloat(model[key]) >= 2016) {
                      model[key] = 2016;
                  }
                  else if (parseFloat(model[key]) <= 1) {
                      model[key] = 1;
                  }
                  else if (model[key].toString().length > 5) {
                      model[key] = parseFloat(model[key].toString().substring(0, 5));
                  }
              }
          }
      };

      var SaveOrEdit = function (editar) {

          $('input').removeClass("alert-danger");
          $('select').removeClass("alert-danger");

          if ($scope.meuForm.$valid && $scope.Veiculo.Model.Ano >= 1890) {

              $("#loading").modal({
                  keyboard: false,
                  backdrop: 'static'
              });

              var sucesso = function () {
                  carregarVeiculos();
                  $("#loading").modal("hide");

                  $("#modalAlerta").modal("show");
                  $(".msgSucesso").show();
                  $(".msgErro").hide();
                  setTimeout(function () {
                      $("#modalAlerta").modal("hide")
                  }, 1800);
                  $scope.Veiculo.Model = {};
              };

              var erro = function () {
              };


              if (editar) {
                  $http.put("http://localhost:54698/api/Veiculos/", $scope.Veiculo.Model)
                  .then(sucesso, erro);
              }
              else {
                  $http.post("http://localhost:54698/api/Veiculos/", $scope.Veiculo.Model)
                  .then(sucesso, erro);
              }
          }
          else {
              $("#modalAlerta").modal("show");
              $(".msgSucesso").hide();
              $(".msgErro").show();

              if ($scope.Veiculo.Model.Ano < 1890) {

                  $("#lblErro").text("Ano deve ser maior do que 1889");
                  $("#txtAno").addClass("alert-danger");
              }
              else {
                  $("#lblErro").text("Erro! Preencha os campos em vermelho");

                  $.each($scope.meuForm.$error, function (i, tipoDeErro) {
                      $.each(tipoDeErro, function (j, campo) {
                          $("[name='" + campo.$name + "']").addClass("alert-danger");
                      });
                  });
              }
          }
      };

      var carregarTipos = function () {
          $("#loading").modal({
              keyboard: false,
              backdrop: 'static'
          });
          var sucesso = function (result) {
              $scope.Veiculo.Tipos = result.data;
              $scope.Veiculo.Model.TipoDeVeiculo = result.data[0];
              carregarFabricantes();
          };

          var erro = function (result) {
              $("#loading").modal("hide");
          };

          $http.get("http://localhost:54698/api/TipoDeVeiculo")
                  .then(sucesso, erro);
      }();

      var carregarFabricantes = function () {
          var sucesso = function (result) {
              $scope.Veiculo.Fabricantes = result.data;
              $scope.Veiculo.Model.Fabricante = result.data[0];
              carregarHabilidades();
          };

          var erro = function (result) {
              $("#loading").modal("hide");
          };

          $http.get("http://localhost:54698/api/Fabricante")
                  .then(sucesso, erro);
      };

      var carregarHabilidades = function () {
          var sucesso = function (result) {
              $scope.Veiculo.Habilidades = result.data;
              carregarVeiculos();
              $("#loading").modal("hide");
          };

          var erro = function (result) {
              $("#loading").modal("hide");
          };

          $http.get("http://localhost:54698/api/Habilidade")
                  .then(sucesso, erro);
      };

      var carregarVeiculos = function () {
          var sucesso = function (result) {
              $scope.Veiculos = result.data;
              $("#loading").modal("hide");
          };

          var erro = function (result) {
              $("#loading").modal("hide");
          };

          $http.get("http://localhost:54698/api/Veiculos")
                  .then(sucesso, erro);
      };
  });