Public Class Tabuleiro

    '=========================================================================================================================='

    'Variaveis Globais no Modulo: '

    '         - tabuleiro_matriz    (matriz)    : integer   - Matriz que Indica o Tabuleiro'
    '         - jogador1            (Indicador) : string    - Um indicador do Jogador1 para utilizar ao realizar acoes de jogadores'
    '         - jogador2            (Indicador) : string    - Um indicador do Jogador2 para utilizar ao realizar acoes de jogadores' 
    '         - jogadorAtual        (jogador)   : jogador   - Uma string que indica um jogador quanto ao seu indicador -- Por Default Ao Iniciar sera o Jogador 1'
    '         - contagem            (Joagadas)  : integer   - Um inteiro para contar o total de Jogadas'

    '=========================================================================================================================='

    ' Esta Funcao é utilizada para Preencher a Matriz com cada "Jogada" efetuada pelo utilizador
    ' Aqui ira Definir na Matriz global cada Jogada na sua posicao conforme o tabuleiro e os botoes
    ' Parametros:
    '           # sender As Object : Receber Um (sender) do tipo de objeto, este e o objecto que foi selecionado.     
    Public Sub novaPosicao(nomeBotao As String)
        If nomeBotao = Button1.Name Then
            tabuleiro_matriz(0, 0) = jogadorAtual
        ElseIf nomeBotao = Button2.Name Then
            tabuleiro_matriz(0, 1) = jogadorAtual
        ElseIf nomeBotao = Button3.Name Then
            tabuleiro_matriz(0, 2) = jogadorAtual
        ElseIf nomeBotao = Button4.Name Then
            tabuleiro_matriz(1, 0) = jogadorAtual
        ElseIf nomeBotao = Button5.Name Then
            tabuleiro_matriz(1, 1) = jogadorAtual
        ElseIf nomeBotao = Button6.Name Then
            tabuleiro_matriz(1, 2) = jogadorAtual
        ElseIf nomeBotao = Button7.Name Then
            tabuleiro_matriz(2, 0) = jogadorAtual
        ElseIf nomeBotao = Button8.Name Then
            tabuleiro_matriz(2, 1) = jogadorAtual
        ElseIf nomeBotao = Button9.Name Then
            tabuleiro_matriz(2, 2) = jogadorAtual
        End If
    End Sub

    '=========================================================================================================================='

    ' Esta Funcao é utilizada para realizar cada "Jogada" efetuada pelo utilizador
    ' Aqui ira preencher o botao selecionado.
    ' No final coloca o Botao .Enabled como False assim nao e possivel voltar a selecionalo
    ' Parametros:
    '           # sender As Object : Receber Um (sender) do tipo de objeto, este e o objecto que foi selecionado.      
    Public Sub jogar(sender As Object)
        sender.BackgroundImage = My.Resources.ResourceManager.GetObject(jogadorAtual)
        sender.BackgroundImageLayout = ImageLayout.Stretch
        sender.Enabled = False
    End Sub

    '=========================================================================================================================='

    ' Esta Funcao é utilizada para Verificar se algum Jogador Ganhou o Jogo
    ' Aqui ira Verificar a matriz do Tabuleiro e Caso alguem complete uma linha ou uma diagonal entao ira ganhar.
    ' Parametros:
    '           #..    
    Public Sub verificar()

        'Varias Auxiliares de Verificacao
        Dim i As Integer = 0 'Horizontal
        Dim j As Integer = 0 'Vertical

        'Diagonal
        Dim k As Integer = 0
        Dim l As Integer = 0

        'Variaveis Para Verificar vencedor
        Dim valor As String
        Dim vencedor As Boolean = False

        '''''

        'Verificar Horizontalmente todas as Linhas
        '   Percorre o (i) que simboliza cada linha e verifica se o valor de cada posicao e igual
        '   Caso seja, o Jogador Ganha
        While i <= 2
            If (tabuleiro_matriz(i, 0) = jogador1 Or tabuleiro_matriz(i, 0) = jogador2) And (tabuleiro_matriz(i, 0) = tabuleiro_matriz(i, 1)) And (tabuleiro_matriz(i, 0) = tabuleiro_matriz(i, 2)) Then
                vencedorLbl.Text = jogadorAtual + " Venceu!"
                ganhar()
            End If
            i += 1
        End While

        '===============
        '===============

        'Verificar Verticalmente todas as Linhas
        '   Percorre o (j) que simboliza cada coluna e verifica se o valor de cada posicao e igual
        '   Caso seja, o Jogador Ganha
        While j <= 2
            If (tabuleiro_matriz(0, j) = jogador1 Or tabuleiro_matriz(0, j) = jogador2) And (tabuleiro_matriz(0, j) = tabuleiro_matriz(1, j)) And (tabuleiro_matriz(0, j) = tabuleiro_matriz(2, j)) Then
                vencedorLbl.Text = jogadorAtual + " Venceu!"
                ganhar()
            End If
            j += 1
        End While

        '===============
        '===============

        'Verificar A diagonal Principal (da esquerda para a direita)
        '   Percorre o (k - Linhas) e (l - Colunas), caso (k=l), esteja na diagonal principal
        '   por isso verifica se o (valor - Valor da Primeira posicao da diagonal) é igual à posição atual
        '   Caso sejam todas iguais, o Jogador Ganha

        If (tabuleiro_matriz(0, 0) = jogador1 Or tabuleiro_matriz(0, 0) = jogador2) Then
            valor = tabuleiro_matriz(0, 0)
            For k = 0 To 2
                For l = 0 To 2
                    If (k = l) Then
                        If (valor = tabuleiro_matriz(k, l)) Then
                            vencedor = True
                        Else
                            vencedor = False
                        End If
                    End If
                Next
            Next
            If (vencedor) Then
                vencedorLbl.Text = jogadorAtual + " Venceu!"
                ganhar()
            End If
        End If

        '===============
        '===============

        'Verificar A diagonal Secundaria (da esquerda para a direita)
        '   Percorre o (k - Linhas) e (l - Colunas), caso ((k + l) = (n - 1) -- (n) - Numero de colunas), esteja na diagonal secundaria
        '   por isso verifica se o (valor - Valor da Primeira posicao da diagonal) é igual à posição atual
        '   Caso sejam todas iguais, o Jogador Ganha
        If (tabuleiro_matriz(0, 2) = jogador1 Or tabuleiro_matriz(0, 2) = jogador2) Then
            valor = tabuleiro_matriz(0, 2)
            For k = 0 To 2
                For l = 0 To 2
                    If ((k + l) = (3 - 1)) Then
                        If (valor = tabuleiro_matriz(k, l)) Then
                            vencedor = True
                        Else
                            vencedor = False
                        End If
                    End If
                Next
            Next
            If (vencedor) Then
                vencedorLbl.Text = jogadorAtual + " Venceu!"
                ganhar()
            End If
        End If

        '===============
        '===============

        'Mudar o Jogador Atual
        If (jogadorAtual = jogador1) Then
            jogadorAtual = jogador2
        Else
            jogadorAtual = jogador1
        End If
        jgrAtual_lbl.Text = jogadorAtual

    End Sub

    '=========================================================================================================================='

    ' Esta Funcao é utilizada para Realizar as acoes necessarias quando algum jogador ganha - O jogo acaba
    ' Aqui ira bloquear a Form do Tabuleiro,sendo assim impossivel continuar a jogar, e mostrar a Frame Da Vitoria
    ' Parametros:
    '           #..    
    Public Sub ganhar()
        Me.Hide()
        Vitoria.Activate()
        Vitoria.Show()
    End Sub
    '=========================================================================================================================='
    '--------------------------------------------------------------------------------------------------------------------------'
    'APENAS PARA O PROGRAMADOR'
    ' ESCREVE LA AS POSICOES DA MATRIZ PREENCHIDAS PARA AJUDAR NA VISUALIZACAO DA MATRIZ
    Public Sub matriz()
        testeLbl1.Text = tabuleiro_matriz(0, 0)
        testeLbl2.Text = tabuleiro_matriz(0, 1)
        testeLbl3.Text = tabuleiro_matriz(0, 2)
        testeLbl4.Text = tabuleiro_matriz(1, 0)
        testeLbl5.Text = tabuleiro_matriz(1, 1)
        testeLbl6.Text = tabuleiro_matriz(1, 2)
        testeLbl7.Text = tabuleiro_matriz(2, 0)
        testeLbl8.Text = tabuleiro_matriz(2, 1)
        testeLbl9.Text = tabuleiro_matriz(2, 2)
    End Sub

    '=========================================================================================================================='

    ' Esta Funcao é chamada quando um botao no tanuleiro e selecionado, isto quer dizer que foi realizada uma "jogada"
    ' De seguida e chamado a funcao de //jogar(sender)// que envia como parametro o (sender) desta funcao, sendo o sender o Botao que foi selecionado
    ' Assim como definir qual jogador sera a seguir (Trocar o Jogador Atual)
    ' Parametros:
    '           # Aqui sao os Default do VB para eventos do tipo 
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click, Button2.Click, Button3.Click,
                                                                        Button4.Click, Button5.Click, Button6.Click,
                                                                        Button7.Click, Button8.Click, Button9.Click

        ' A partir daqui trabalhar com o (sender) para determinar que botao foi clicado
        Dim botaoSelecionado As Button = CType(sender, Button)
        Dim nomeBotao As String = botaoSelecionado.Name

        novaPosicao(nomeBotao)
        jogar(sender)
        matriz()
        verificar()



    End Sub

    '=========================================================================================================================='



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        jgrAtual_lbl.Text = jogadorAtual
    End Sub


End Class
