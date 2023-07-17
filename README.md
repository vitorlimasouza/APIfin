# Rotas
A APIfin tem as seguintes rotas:

Movimentação

    GET /api/movement: Retorna todas as movimentações.
    GET /api/movement/{id}: Pesquisa a movimentação pelo Id.
    GET /api/movement/period/{id}: Pesquisa a movimentação pelo Id do periodo.
    POST /api/movement: Cria uma movimentação(Observação: cria um periodo se não houver).
    PUT /api/movement/{id}: Atualiza uma movimentação existente.
    DELETE /api/news/{id}: Exclui uma Movimentação.

Periodo

    GET /api/period: Retorna todos os periodos.
    GET /api/period/statement/{Year}: Retorna o extrato do ano.
    GET /api/period/statement/mouth={mouth}&year={year}: Retorna extrato do mês.
