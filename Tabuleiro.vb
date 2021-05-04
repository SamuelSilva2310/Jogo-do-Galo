﻿Public Class Tabuleiro

    '=========================================================================================================================='

    'Variaveis Globais no Modulo: '

    '         - tabuleiro_matriz    (matriz)    : integer   - Matriz que Indica o Tabuleiro'
    '         - jogador1            (Indicador) : string    - Um indicador do Jogador1 para utilizar ao realizar acoes de jogadores'
    '         - jogador2            (Indicador) : string    - Um indicador do Jogador2 para utilizar ao realizar acoes de jogadores' 
    '         - jogadorAtual        (jogador)   : jogador   - Uma string que indica um jogador quanto ao seu indicador -- Por Default Ao Iniciar sera o Jogador 1'
    '         - contagem            (Joagadas)  : integer   - Um inteiro para contar o total de Jogadas'

    '=========================================================================================================================='

    Public Sub resetJogo()
        Dim limpo(2, 2) As String
        tabuleiro_matriz = limpo

        For Each bt As Button In Me.Controls.OfType(Of Button)()
            bt.BackgroundImage = Nothing
            bt.Enabled = True
        Next
        jogadorAtual = jogador1
        jgrAtual_lbl.Text = jogadorAtual

    End Sub


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

        'Verificar Verticalmente todas as Colunas
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
        '

        'Estava Assim:
        'If (tabuleiro_matriz(0, 0) = jogador1 Or tabuleiro_matriz(0, 0) = jogador2) Then
        '    valor = tabuleiro_matriz(0, 0)
        '    For k = 0 To 2
        '        For l = 0 To 2
        '            If (k = l) Then
        '                If (valor = tabuleiro_matriz(k, l)) Then
        '                    vencedor = True
        '                Else
        '                    vencedor = False
        '                End If
        '            End If
        '        Next
        '    Next
        '    If (vencedor) Then
        '        vencedorLbl.Text = jogadorAtual + " Venceu!"
        '        ganhar()
        '    End If
        'End If

        '-----------------------------------------
        'Assim e mais eficiente e rapido e simples:
        '-----------------------------------------

        If (tabuleiro_matriz(0, 0) = jogador1 Or tabuleiro_matriz(0, 0) = jogador2) And (tabuleiro_matriz(0, 0) = tabuleiro_matriz(1, 1)) And (tabuleiro_matriz(0, 0) = tabuleiro_matriz(2, 2)) Then
            vencedorLbl.Text = jogadorAtual + " Venceu!"
            ganhar()
        End If

        '===============
        '===============

        'Verificar A diagonal Secundaria (da esquerda para a direita)
        '   Percorre o (k - Linhas) e (l - Colunas), caso ((k + l) = (n - 1) -- (n) - Numero de colunas), esteja na diagonal secundaria
        '   por isso verifica se o (valor - Valor da Primeira posicao da diagonal) é igual à posição atual
        '   Caso sejam todas iguais, o Jogador Ganha
        ' Estava Assim:

        'If (tabuleiro_matriz(0, 2) = jogador1 Or tabuleiro_matriz(0, 2) = jogador2) Then
        '    valor = tabuleiro_matriz(0, 2)
        '    For k = 0 To 2
        '        For l = 0 To 2
        '            If ((k + l) = (3 - 1)) Then
        '                If (valor = tabuleiro_matriz(k, l)) Then
        '                    vencedor = True
        '                Else
        '                    vencedor = False
        '                End If
        '            End If
        '        Next
        '    Next
        '    If (vencedor) Then
        '        vencedorLbl.Text = jogadorAtual + " Venceu!"
        '        ganhar()
        '    End If
        'End If

        '-----------------------------------------
        'Assim e mais eficiente e rapido e simples:
        '-----------------------------------------

        If (tabuleiro_matriz(0, 2) = jogador1 Or tabuleiro_matriz(0, 2) = jogador2) And (tabuleiro_matriz(0, 2) = tabuleiro_matriz(1, 1)) And (tabuleiro_matriz(0, 2) = tabuleiro_matriz(2, 0)) Then
            vencedorLbl.Text = jogadorAtual + " Venceu!"
            ganhar()
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
    'Da reset no jogo Tambem e na vitoria mostra o jogador vencedor
    ' Parametros:
    '           #..    
    Public Sub ganhar()
        Me.Hide()

        If jogadorAtual = jogador1 Then
            Vitoria.player_lbl.Text = "Jogador 1"
        Else
            Vitoria.player_lbl.Text = "Jogador 2"
        End If
        resetJogo()
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

        'Depois Joga O Bot
        If AI Then
            novaPosicaoAI(melhorJogada(tabuleiro_matriz))
            matriz()
            verificar()
        End If



    End Sub

    '=========================================================================================================================='



    Private Sub Tabuleiro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        jgrAtual_lbl.Text = jogadorAtual
    End Sub

    '=========================================================================================================================='
    '=========================================================================================================================='
    'FUNCOES UTILIZADAS PELO AI
    '=========================================================================================================================='
    '=========================================================================================================================='

    'JOGAR'
    '-----
    'novaPosicaoAI
    Private Sub novaPosicaoAI(pos As Array)
        tabuleiro_matriz(pos(0), pos(1)) = jogadorAtual
    End Sub

    'EVALUATE
    ' Esta Funcao é chamada quando for necessaria realizar uma jogada pelo computador,
    ' Esta Avalia o quadro e se alguem ganhou devolve 10 se for vantajoso ou -10 de for o adversario, se ninguem ganhou devolve 0
    ' Parametros:
    '           # tabuleiro : o tabuleiro num certo momento que ira ser verificado


    Private Function avaliar(tabuleiro As Array) As Integer
        Dim i As Integer

        'Check Rows
        For i = 0 To 2
            If (tabuleiro(i, 0) = jogador1 Or tabuleiro(i, 0) = jogador2) And tabuleiro(i, 0) = tabuleiro(i, 1) And tabuleiro(i, 0) = tabuleiro(i, 2) Then
                If jogadorAtual = jogador2 Then
                    Return 10
                Else
                    Return -10
                End If
            End If
            Continue For
        Next

        'Check Collumns
        For i = 0 To 2
            If (tabuleiro(0, i) = jogador1 Or tabuleiro(0, i) = jogador2) And tabuleiro(0, i) = tabuleiro(1, i) And tabuleiro(0, i) = tabuleiro(2, i) Then
                Continue For
            End If
            If jogadorAtual = jogador2 Then
                Return 10
            Else
                Return -10
            End If
        Next

        'Check Diagonal
        If (tabuleiro(0, 0) = jogador1 Or tabuleiro(0, 0) = jogador2) And (tabuleiro(0, 0) = tabuleiro(1, 1)) And (tabuleiro(0, 0) = tabuleiro(2, 2)) Then
            If jogadorAtual = jogador2 Then
                Return 10
            Else
                Return -10
            End If
        End If

        'Check Secondary Diagonal
        If (tabuleiro(0, 2) = jogador1 Or tabuleiro(0, 2) = jogador2) And (tabuleiro(0, 2) = tabuleiro_matriz(1, 1)) And (tabuleiro(0, 2) = tabuleiro_matriz(2, 0)) Then
            If jogadorAtual = jogador2 Then
                Return 10
            Else
                Return -10
            End If
        End If

        Return 0

    End Function


    '=========================================================================================================================='
    '   jogadasDisponiveis
    ' Esta Funcao é chamada quando for necessaria uma verificacao se existem jogadas disponiveis,
    ' Parametros:
    '           # tabuleiro : o tabuleiro num certo momento que ira ser verificado
    Private Function jogadasDisponiveis(tabuleiro As Array) As Boolean
        Dim i As Integer
        For i = 0 To 2
            If tabuleiro(i, 0) <> jogador1 Or tabuleiro(i, 0) <> jogador2 Or
               tabuleiro(i, 1) <> jogador1 Or tabuleiro(i, 1) <> jogador2 Or
               tabuleiro(i, 2) <> jogador1 Or tabuleiro(i, 2) <> jogador2 Then

                Return True
            End If
        Next
        Return False
    End Function



    '=========================================================================================================================='

    ' Esta Funcao impoementa o famoso algoritmo Minimax, este avalia todas as possibilidades e degvolve a melhor escolha
    ' 
    ' Parametros:
    '           # tabuleiro : o tabuleiro num certo momento que ira ser verificado
    '           # depth     : a profundidade com que op algoritmo ja percorreu
    '           # isMax     : um boolean que identifica se 
    Private Function minimax(tabuleiro As Array, depth As Integer, isMax As Boolean) As Integer
        Dim score = avaliar(tabuleiro)

        'Se o jogo ja terminou,
        'Ganhou o computador, 
        'Ganhou o Jogador,
        'Nao existem mais jogadas, Empatou
        If score = 10 Then
            Return score
        ElseIf score = -10 Then
            Return score

        ElseIf Not jogadasDisponiveis(tabuleiro) Then
            Return 0
        End If

        If isMax Then
            Dim best = -1000
            Dim i, j As Integer

            For i = 0 To 2
                For j = 0 To 2
                    If tabuleiro(i, j) <> jogador1 Or tabuleiro(i, j) <> jogador2 Then
                        tabuleiro(i, j) = jogador2
                        best = Math.Max(best, minimax(tabuleiro, depth + 1, Not isMax))

                        tabuleiro(i, j) = Nothing
                    End If
                Next
            Next
            Return best

        Else
            Dim best = 1000
            Dim i, j As Integer

            For i = 0 To 2
                For j = 0 To 2
                    If tabuleiro(i, j) <> jogador1 Or tabuleiro(i, j) <> jogador2 Then
                        tabuleiro(i, j) = jogador1
                        best = Math.Min(best, minimax(tabuleiro, depth + 1, Not isMax))

                        tabuleiro(i, j) = Nothing
                    End If
                Next
            Next
            Return best


        End If
    End Function

    '=========================================================================================================================='
    'Esta Funcao serve para Encontrar a melhor jogada para o AI
    ' Parametros:
    '           # tabuleiro : o tabuleiro num certo momento que ira ser verificado
    Private Function melhorJogada(tabuleiro As Array) As Array
        Dim bestVal = -1000
        Dim bestMove(1) As Integer
        Dim moveVal
        Dim i, j As Integer

        For i = 0 To 2
            For j = 0 To 2
                If tabuleiro(i, j) <> jogador1 Or tabuleiro(i, j) <> jogador2 Then
                    tabuleiro(i, j) = jogador2
                    moveVal = minimax(tabuleiro, 0, False)
                    tabuleiro(i, j) = Nothing

                    If moveVal > bestVal Then
                        bestMove(0) = i
                        bestMove(1) = j
                        bestVal = moveVal
                    End If
                End If
            Next
        Next
        Return bestMove

    End Function



End Class
