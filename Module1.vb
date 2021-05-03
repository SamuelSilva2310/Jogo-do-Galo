'============================================='
'                    MODULO                   '
'============================================='
'Aqui ira ser Criado todas as variaveis globais do programa '
'                                                           '
'Variaveis Necessarias: '

'         - Tabuleiro       (matriz)    : integer   - Matriz que Indica o Tabuleiro'
'         - Jogador 1       (Indicador) : string    - Um indicador do Jogador1 para utilizar ao realizar acoes de jogadores'
'         - Jogador 2       (Indicador) : string    - Um indicador do Jogador2 para utilizar ao realizar acoes de jogadores' 
'         - Jogador Atual   (jogador)   : jogador   - Uma string que indica um jogador quanto ao seu indicador -- Por Default Ao Iniciar sera o Jogador 1'
'         - Contagem        (Joagadas)  : integer   - Um inteiro para contar o total de Jogadas'
'         - Vencedor        (jogador)   : integer   - Indica o Jogador Vencedor'

Module Module1
    Public tabuleiro_matriz(2, 2) As String
    Public jogador1 As String = "j1"
    Public jogador2 As String = "j2"
    Public jogadorAtual As String = jogador1
    Public contagem As Integer = 0
    Public vencedor As String
End Module