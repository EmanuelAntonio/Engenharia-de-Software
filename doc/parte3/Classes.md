Classes
=======

![Diagrama de Classes](diagrama_de_classes.png?raw=true "Diagrama de classes")

Perfil
------

#### Atributos:

- -nick: **String**
- -nomeEmpresa: **String**
- -dia: **int**
- -mes: **int**
- -ano: **int**
- -etapa: **int**
- -maximoFuncionarios: **int**
- -pontosPesquisa: **int**
- -verba: **float**

#### Métodos:

#### Ligações:

- Funcionario: (0..\*)
- Projetos: (0..\*)
- Pesquisa: (0..\*)


Funcionario
-----------

#### Atributos:

- -habilidadeTecnologia: **int**
- -habilidadeDesign: **int**
- -habilidadePesquisa: **int**
- -salario: **float**

#### Métodos:

#### Ligações:

- Perfil: (0..1)


Projeto
-------

#### Atributos:

- -valorPagamento: **float**
- -multaAtraso: **float**
- -tipoEmpresa: **String**
- -tamanhoEmpresa: **int**
- -experienciaUsuario: **int**
- -prioridadeColetaDados: **float**
- -prioridadeEstudoDominio: **float**
- -prioridadeDocumentacao: **float**
- -prioridadeLegibilidade: **float**
- -prioridadeQualidadeSolucao: **float**
- -prioridadeInterface: **float**
- -prioridadeTestes: **float**
- -prioridadeAvaliacaoCliente: **float**
- -prioridadeImplantacao: **float**
- -pontosErro: **int**
- -pontosTecnologia: **int**
- -pontosDesign: **int**

#### Métodos:

#### Ligações:

- Perfil: (0..1)


Pesquisa
--------

#### Atributos:

- -nome: **String**
- -custoPontosPesquisa: **int**
- -custoDinheiro: **float**
- -tempoPesquisa: **int**

#### Métodos:

#### Ligações:

- Perfil: (0..1)
