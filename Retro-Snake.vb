Public Class Snake
    '############# RetroSnake v1.3 ##############
    '############################################
    '############################################
    '#      12/15/2010 Program Written By:      #
    '#       Steven Elberger -- Website:        #
    '#       Http://www.corruptcoding.com       #
    '############################################
    Public iLength As Integer = 0 'Length of snake.
    Public m As Integer = 150 'Full length of snake.
    Public k As Keys 'Direction of snake.
    Public p(m) As Point 'Array of points.
    Public pA As Point 'Apple.
    Public X1, X2, Y1, Y2, iC As Integer 'X1 and Y1 are the snake head's X and Y values. X2 and Y2 are the apple's X and Y values. C is for the color mode select case.
    Public bEaten As Boolean 'Apple generating test variable.
    Public bGreen, bBlack, bBlue, _
        bOrange, bPurple As Boolean 'Color mode booleans.
    Public bEasy, bNormal, bHard, bInsane As Boolean 'Game mode difficulties.
    Public bHighscorecheck, bPaused, bGameOver As Boolean 'High score checker, paused game checker & game over checker.
    Public bSound As Boolean 'Determines if sound is on or not.
    Private Sub MoveSnake(ByVal g As Graphics)
        'Update the points in the array because
        ' the snake is going to be painted again.
        For i As Integer = iLength To 1 Step -1
            'From iLength down to 1 point behind
            ' the snake head, shift all points to
            ' the one before them and decrement i
            ' by 1.
            p(i) = p(i - 1)
        Next
        'Move the snake head to a new point.
        p(0) = New Point(X1, Y1)
        'Call the PaintSnake procedure and use
        ' the g graphics class to paint the snake.
        PaintSnake(g)
    End Sub
    Private Sub PaintSnake(ByVal g As Graphics)
        'If the apple has not been eaten,
        ' then keep drawing the apple at its
        ' current point.
        If bEaten = False Then
            pA.X = X2
            pA.Y = Y2
            g.FillRectangle(Brushes.Red, New Rectangle(pA, New Size(10, 10)))
            'If the apple has been eaten,
            ' generate new points for the
            ' next apple and set bEaten to
            ' False.
        ElseIf bEaten = True Then
            X2 = Math.Round(Rnd() * 10) * 20
            Y2 = Math.Round(Rnd() * 10) * 20
            bEaten = False
        End If

        Select Case iC
            Case 0
                'Paint the head of the snake.
                g.FillRectangle(Brushes.Green, New Rectangle(p(0), New Size(10, 10)))
                'For the entire length of the snake,
                ' except for the head, paint a blue
                ' square to represent the body.
                For i As Integer = iLength To 1 Step -1
                    g.FillRectangle(Brushes.DarkSeaGreen, New Rectangle(p(i), New Size(10, 10)))
                    'If the snake head's X and Y values
                    ' are equal to any other snake body
                    ' parts' X and Y values, then they are
                    ' intersecting and the game is over.
                    If p(0).X = p(i).X And p(0).Y = p(i).Y Then
                        tmrTime.Stop()
                        bGameOver = True
                        CheckScore(lblPoints)
                        ReEnable(btnStart, MenuStrip1, rdoGreen, rdoBlack, _
                                 rdoBlue, rdoOrange, rdoPurple, grpColor, chkRainbow, _
                                 chkNoWalls, grpOptions)
                    End If
                Next
            Case 1
                'Paint the head of the snake.
                g.FillRectangle(Brushes.Black, New Rectangle(p(0), New Size(10, 10)))
                'For the entire length of the snake,
                ' except for the head, paint a blue
                ' square to represent the body.
                For i As Integer = iLength To 1 Step -1
                    g.FillRectangle(Brushes.DimGray, New Rectangle(p(i), New Size(10, 10)))
                    'If the snake head's X and Y values
                    ' are equal to any other snake body
                    ' parts' X and Y values, then they are
                    ' intersecting and the game is over.
                    If p(0).X = p(i).X And p(0).Y = p(i).Y Then
                        tmrTime.Stop()
                        bGameOver = True
                        CheckScore(lblPoints)
                        ReEnable(btnStart, MenuStrip1, rdoGreen, rdoBlack, _
                                 rdoBlue, rdoOrange, rdoPurple, grpColor, chkRainbow, _
                                 chkNoWalls, grpOptions)
                    End If
                Next
            Case 2
                'Paint the head of the snake.
                g.FillRectangle(Brushes.Blue, New Rectangle(p(0), New Size(10, 10)))
                'For the entire length of the snake,
                ' except for the head, paint a blue
                ' square to represent the body.
                For i As Integer = iLength To 1 Step -1
                    g.FillRectangle(Brushes.RoyalBlue, New Rectangle(p(i), New Size(10, 10)))
                    'If the snake head's X and Y values
                    ' are equal to any other snake body
                    ' parts' X and Y values, then they are
                    ' intersecting and the game is over.
                    If p(0).X = p(i).X And p(0).Y = p(i).Y Then
                        tmrTime.Stop()
                        bGameOver = True
                        CheckScore(lblPoints)
                        ReEnable(btnStart, MenuStrip1, rdoGreen, rdoBlack, _
                                 rdoBlue, rdoOrange, rdoPurple, grpColor, chkRainbow, _
                                 chkNoWalls, grpOptions)
                    End If
                Next
            Case 3
                'Paint the head of the snake.
                g.FillRectangle(Brushes.OrangeRed, New Rectangle(p(0), New Size(10, 10)))
                'For the entire length of the snake,
                ' except for the head, paint a blue
                ' square to represent the body.
                For i As Integer = iLength To 1 Step -1
                    g.FillRectangle(Brushes.Orange, New Rectangle(p(i), New Size(10, 10)))
                    'If the snake head's X and Y values
                    ' are equal to any other snake body
                    ' parts' X and Y values, then they are
                    ' intersecting and the game is over.
                    If p(0).X = p(i).X And p(0).Y = p(i).Y Then
                        tmrTime.Stop()
                        bGameOver = True
                        CheckScore(lblPoints)
                        ReEnable(btnStart, MenuStrip1, rdoGreen, rdoBlack, _
                                 rdoBlue, rdoOrange, rdoPurple, grpColor, chkRainbow, _
                                 chkNoWalls, grpOptions)
                    End If
                Next
            Case 4
                'Paint the head of the snake.
                g.FillRectangle(Brushes.Purple, New Rectangle(p(0), New Size(10, 10)))
                'For the entire length of the snake,
                ' except for the head, paint a blue
                ' square to represent the body.
                For i As Integer = iLength To 1 Step -1
                    g.FillRectangle(Brushes.MediumOrchid, New Rectangle(p(i), New Size(10, 10)))
                    'If the snake head's X and Y values
                    ' are equal to any other snake body
                    ' parts' X and Y values, then they are
                    ' intersecting and the game is over.
                    If p(0).X = p(i).X And p(0).Y = p(i).Y Then
                        tmrTime.Stop()
                        bGameOver = True
                        CheckScore(lblPoints)
                        ReEnable(btnStart, MenuStrip1, rdoGreen, rdoBlack, _
                                 rdoBlue, rdoOrange, rdoPurple, grpColor, chkRainbow, _
                                 chkNoWalls, grpOptions)
                    End If
                Next
            Case 5
                'Dimension iColor integer for selecting
                ' a random color for the rainbow mode.
                Dim iColor As Integer

                'Paint the head of the snake.
                g.FillRectangle(Brushes.Black, New Rectangle(p(0), New Size(10, 10)))
                'For the entire length of the snake,
                ' except for the head, paint a blue
                ' square to represent the body.
                For i As Integer = iLength To 1 Step -1
                    'Set iColor = to a random number,
                    ' 1 - 6, for each square in the snake
                    ' and, depending upon which number it's
                    ' equal to, color that square a certain color.
                    iColor = Int(Rnd() * 6) + 1
                    Select Case iColor
                        Case 1
                            g.FillRectangle(Brushes.Black, New Rectangle(p(i), New Size(10, 10)))
                        Case 2
                            g.FillRectangle(Brushes.Red, New Rectangle(p(i), New Size(10, 10)))
                        Case 3
                            g.FillRectangle(Brushes.Blue, New Rectangle(p(i), New Size(10, 10)))
                        Case 4
                            g.FillRectangle(Brushes.Green, New Rectangle(p(i), New Size(10, 10)))
                        Case 5
                            g.FillRectangle(Brushes.Purple, New Rectangle(p(i), New Size(10, 10)))
                        Case 6
                            g.FillRectangle(Brushes.OrangeRed, New Rectangle(p(i), New Size(10, 10)))
                    End Select
                    'If the snake head's X and Y values
                    ' are equal to any other snake body
                    ' parts' X and Y values, then they are
                    ' intersecting and the game is over.
                    If p(0).X = p(i).X And p(0).Y = p(i).Y Then
                        tmrTime.Stop()
                        CheckScore(lblPoints)
                        bGameOver = True
                        ReEnable(btnStart, MenuStrip1, rdoGreen, rdoBlack, _
                                 rdoBlue, rdoOrange, rdoPurple, grpColor, chkRainbow, _
                                 chkNoWalls, grpOptions)
                    End If
                Next
        End Select

        'If the snake head's X and Y values
        ' are equal to the apple's X and Y
        ' values, then the apple has been eaten
        ' and another square must be added to the
        ' snake. Update the score.
        If p(0).X = pA.X And p(0).Y = pA.Y Then
            bEaten = True
            iLength += 1
            Points()
            If bSound = True Then
                My.Computer.Audio.Play(My.Resources.sonarbeep, AudioPlayMode.Background)
            End If
        End If
    End Sub
    Private Sub tmrTime_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrTime.Tick
        'Create image for the game.
        Dim bMap As New Bitmap(260, 260)
        'Set g as a graphics class equal to 
        ' the game image.
        Dim g As Graphics = Graphics.FromImage(bMap)

        'Call the MoveSnake procedure,
        ' which uses the graphics class,
        ' the SnakeDirection procedure,
        ' and the BoundariesCheck procedure
        ' to move the snake, which also calls
        ' the PaintSnake procedure, checks which
        ' direction the snake is headed, and if
        ' the snake is out of bounds or not.
        MoveSnake(g)
        If chkNoWalls.Checked = True Then
            'Use SnakeDirections2 routine to
            ' alter what happens when X and Y
            ' values of p(0) go beyond bMap's
            ' X and Y values.
            SnakeDirection2()
        ElseIf chkNoWalls.Checked = False Then
            SnakeDirection()
            BoundariesCheck()
        End If

        'Set the background image of the picture box
        ' to the game image and set the size of the picture
        ' box to the game image's size.
        picBox1.Image = bMap
        'Refresh the picture box.
        picBox1.Refresh()
    End Sub
    Private Sub Snake_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        'If the user pressed the left key and
        ' the snake wasn't going right, set the
        ' direction of the snake to west.
        If e.KeyCode = Keys.Left And k <> Keys.Right Then
            k = Keys.Left
        End If
        'If the user pressed the right key and
        ' the snake wasn't going left, set the
        ' direction of the snake to east.
        If e.KeyCode = Keys.Right And k <> Keys.Left Then
            k = Keys.Right
        End If
        'If the user pressed the up key and
        ' the snake wasn't going down, set the
        ' direction of the snake to north.
        If e.KeyCode = Keys.Up And k <> Keys.Down Then
            k = Keys.Up
        End If
        'If the user pressed the down key and
        ' the snake wasn't going up, set the
        ' direction of the snake to south.
        If e.KeyCode = Keys.Down And k <> Keys.Up Then
            k = Keys.Down
        End If
        If e.KeyCode = Keys.Space And bPaused = True And bGameOver = False Then
            tmrTime.Start()
            e.SuppressKeyPress = True
            bPaused = False
            lblPaused.Visible = False
            If bSound = True Then
                My.Computer.Audio.Play(My.Resources.pop, AudioPlayMode.Background)
            End If
        ElseIf e.KeyCode = Keys.Space And bPaused = False And bGameOver = False Then
            tmrTime.Stop()
            e.SuppressKeyPress = True
            bPaused = True
            lblPaused.Visible = True
            If bSound = True Then
                My.Computer.Audio.Play(My.Resources.pop, AudioPlayMode.Background)
            End If
        End If
    End Sub
    Private Sub SnakeDirection()
        'Update X and Y values of
        ' all points in the array
        ' and update the X and Y
        ' values of the snake head's
        ' next point.
        If k = Keys.Left Then
            p(m).X -= 10
            X1 -= 10
        End If
        If k = Keys.Right Then
            p(m).X += 10
            X1 += 10
        End If
        If k = Keys.Up Then
            p(m).Y -= 10
            Y1 -= 10
        End If
        If k = Keys.Down Then
            p(m).Y += 10
            Y1 += 10
        End If
    End Sub
    Private Sub SnakeDirection2()
        'Update X and Y values of
        ' all points in the array
        ' and update the X and Y
        ' values of the snake head's
        ' next point.
        If k = Keys.Left Then
            p(m).X -= 10
            If p(0).X < 1 Then
                X1 = 260
            End If
            X1 -= 10
        End If
        If k = Keys.Right Then
            p(m).X += 10
            If p(0).X > 249 Then
                X1 = -10
            End If
            X1 += 10
        End If
        If k = Keys.Up Then
            p(m).Y -= 10
            If p(0).Y < 1 Then
                Y1 = 260
            End If
            Y1 -= 10
        End If
        If k = Keys.Down Then
            p(m).Y += 10
            If p(0).Y > 249 Then
                Y1 = -10
            End If
            Y1 += 10
        End If
    End Sub
    Private Sub BoundariesCheck()
        'If the snake head's X value is
        ' above 250 or below 0, then the snake
        ' is out of bounds.
        If p(0).X > 250 Or p(0).X < 0 Then
            tmrTime.Stop()
            bGameOver = True
            CheckScore(lblPoints)
            ReEnable(btnStart, MenuStrip1, rdoGreen, rdoBlack, _
                                 rdoBlue, rdoOrange, rdoPurple, grpColor, chkRainbow, _
                                 chkNoWalls, grpOptions)
            'If the snake head's Y value is
            ' above 250 or below 0, then the snake
            ' is out of bounds.
        ElseIf p(0).Y > 250 Or p(0).Y < 0 Then
            tmrTime.Stop()
            bGameOver = True
            CheckScore(lblPoints)
            ReEnable(btnStart, MenuStrip1, rdoGreen, rdoBlack, _
                                 rdoBlue, rdoOrange, rdoPurple, grpColor, chkRainbow, _
                                 chkNoWalls, grpOptions)
        End If
    End Sub
    Private Sub mnu1Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu1Exit.Click
        'Exit form.
        Me.Dispose()

        'Save highscores list.
        SaveScore()
    End Sub
    Private Sub Points()
        'Update the point label depending upon
        ' what the game mode is.
        If bEasy = True Then
            lblPoints.Text = CInt(lblPoints.Text) + 50
        End If
        If bNormal = True Then
            lblPoints.Text = CInt(lblPoints.Text) + 75
        End If
        If bHard = True Then
            lblPoints.Text = CInt(lblPoints.Text) + 100
        End If
        If bInsane = True Then
            lblPoints.Text = CInt(lblPoints.Text) + 150
        End If
    End Sub
    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        'Start the timer, disable
        ' the start button and menu.
        tmrTime.Start()
        bGameOver = False
        lblPoints.Text = "0"
        btnStart.Enabled = False
        MenuStrip1.Enabled = False
        grpColor.Enabled = False
        grpOptions.Enabled = False

        'Set the snake head's starting
        ' point to (0,0) and generate
        ' new points for the first apple.
        ' Set the direction to south and the
        ' bEaten boolean to False. Reset the length
        ' of the snake back to 1 square and set all
        ' points in the array back to (0,0).
        X1 = 0
        Y1 = 0
        X2 = Math.Round(Rnd() * 10) * 20
        Y2 = Math.Round(Rnd() * 10) * 20
        pA.X = X2
        pA.Y = Y2
        k = Keys.Down
        bEaten = False
        iLength = 0
        For i As Integer = 0 To m
            p(i).X = 0
            p(i).Y = 0
        Next
    End Sub
    Private Sub rdoGreen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoGreen.CheckedChanged
        If rdoGreen.Checked = True Then
            ColorMode(bGreen, bBlack, bBlue, bOrange, bPurple)
            iC = 0
        End If
    End Sub
    Private Sub ColorMode(ByVal b0 As Boolean, ByVal b1 As Boolean, ByVal b2 As Boolean, ByVal b3 As Boolean, _
                          ByVal b4 As Boolean)
        If b0 = True Then
            b1 = False
            b2 = False
            b3 = False
            b4 = False
        End If
    End Sub
    Private Sub rdoBlack_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoBlack.CheckedChanged
        ColorMode(bBlack, bGreen, bBlue, bOrange, bPurple)
        iC = 1
    End Sub
    Private Sub rdoBlue_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoBlue.CheckedChanged
        ColorMode(bBlue, bBlack, bGreen, bOrange, bPurple)
        iC = 2
    End Sub
    Private Sub rdoOrange_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoOrange.CheckedChanged
        ColorMode(bOrange, bBlack, bBlue, bGreen, bPurple)
        iC = 3
    End Sub
    Private Sub rdoPurple_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoPurple.CheckedChanged
        ColorMode(bPurple, bBlack, bBlue, bOrange, bGreen)
        iC = 4
    End Sub
    Private Sub ReEnable(ByVal btn As Button, ByVal mnu As MenuStrip, ByVal rdo0 As RadioButton, ByVal rdo1 As RadioButton, ByVal rdo2 As RadioButton, _
                         ByVal rdo3 As RadioButton, ByVal rdo4 As RadioButton, ByVal grp0 As GroupBox, ByVal chk0 As CheckBox, ByVal chk1 As CheckBox, _
                         ByVal grp1 As GroupBox)
        btn.Enabled = True
        mnu.Enabled = True
        If chkRainbow.Checked = True Then
            grpColor.Enabled = False
            grpOptions.Enabled = True
        ElseIf chkRainbow.Checked = False Then
            grpColor.Enabled = True
            grpOptions.Enabled = True
        End If
    End Sub
    Private Sub chkRainbow_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRainbow.CheckedChanged
        If chkRainbow.Checked = True Then
            grpColor.Enabled = False
            iC = 5
        ElseIf chkRainbow.Checked = False Then
            grpColor.Enabled = True
            ColorCheck(rdoGreen, rdoBlack, rdoBlue, rdoOrange, rdoPurple)
        End If
    End Sub
    Private Sub ColorCheck(ByVal rdo0 As RadioButton, ByVal rdo1 As RadioButton, ByVal rdo2 As RadioButton, ByVal rdo3 As RadioButton, ByVal rdo4 As RadioButton)
        If rdo0.Checked = True Then
            iC = 0
        ElseIf rdo1.Checked = True Then
            iC = 1
        ElseIf rdo2.Checked = True Then
            iC = 2
        ElseIf rdo3.Checked = True Then
            iC = 3
        ElseIf rdo4.Checked = True Then
            iC = 4
        End If
    End Sub
    Private Sub ModeCheck(ByVal m0 As ToolStripMenuItem, ByVal m1 As ToolStripMenuItem, ByVal m2 As ToolStripMenuItem, ByVal m3 As ToolStripMenuItem)
        If m0.Checked = False Then
            m0.Checked = True
            m1.Checked = False
            m2.Checked = False
            m3.Checked = False
        End If
    End Sub
    Private Sub mnu2Easy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu2Easy.Click
        ModeCheck(mnu2Easy, mnu2Normal, mnu2Hard, mnu2Insane)
        bEasy = True
        bNormal = False
        bHard = False
        bInsane = False
        tmrTime.Interval = 200
        lblMode.Text = "Easy"
        lblMode.ForeColor = Color.Green
    End Sub
    Private Sub mnu2Normal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu2Normal.Click
        ModeCheck(mnu2Normal, mnu2Easy, mnu2Hard, mnu2Insane)
        bNormal = True
        bEasy = False
        bHard = False
        bInsane = False
        tmrTime.Interval = 100
        lblMode.Text = "Normal"
        lblMode.ForeColor = Color.Orange
    End Sub
    Private Sub mnu2Hard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu2Hard.Click
        ModeCheck(mnu2Hard, mnu2Normal, mnu2Easy, mnu2Insane)
        bHard = True
        bEasy = False
        bNormal = False
        bInsane = False
        tmrTime.Interval = 75
        lblMode.Text = "Hard"
        lblMode.ForeColor = Color.Red
    End Sub
    Private Sub mnu2Insane_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu2Insane.Click
        ModeCheck(mnu2Insane, mnu2Normal, mnu2Hard, mnu2Easy)
        bInsane = True
        bEasy = False
        bNormal = False
        bHard = False
        tmrTime.Interval = 50
        lblMode.Text = "Insane!"
        lblMode.ForeColor = Color.Blue
    End Sub
    Private Sub Snake_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Game loads automatically at Normal mode.
        bEasy = False
        bNormal = True
        bHard = False
        bInsane = False
        'Game loads unpaused & unplayed.
        bPaused = False
        bGameOver = False
        'Game automatically has sound on.
        bSound = True

        'iPlace can't be 0-4 or else
        ' that number name label will
        ' be blank.
        iPlace = 5

        'Load highscores list.
        LoadScore()

        'If there were no highscores, set
        ' the names to default values.
        If ActualHighscores.lblH0.Text = "" Then
            ActualHighscores.lblH0.Text = "Highscore"
        End If
        If ActualHighscores.lblH1.Text = "" Then
            ActualHighscores.lblH1.Text = "Highscore"
        End If
        If ActualHighscores.lblH2.Text = "" Then
            ActualHighscores.lblH2.Text = "Highscore"
        End If
        If ActualHighscores.lblH3.Text = "" Then
            ActualHighscores.lblH3.Text = "Highscore"
        End If
        If ActualHighscores.lblH4.Text = "" Then
            ActualHighscores.lblH4.Text = "Highscore"
        End If

        'If there were no highscores, set
        ' the scores to default values.
        If ActualHighscores.lblS0.Text = "" Then
            ActualHighscores.lblS0.Text = "1000"
        End If
        If ActualHighscores.lblS1.Text = "" Then
            ActualHighscores.lblS1.Text = "900"
        End If
        If ActualHighscores.lblS2.Text = "" Then
            ActualHighscores.lblS2.Text = "800"
        End If
        If ActualHighscores.lblS3.Text = "" Then
            ActualHighscores.lblS3.Text = "700"
        End If
        If ActualHighscores.lblS4.Text = "" Then
            ActualHighscores.lblS4.Text = "600"
        End If
    End Sub
    Private Sub CheckScore(ByVal points As Label)
        If CInt(points.Text) >= CInt(ActualHighscores.lblS4.Text) Then
            bHighscorecheck = True
        End If

        If bHighscorecheck = True Then
            If CInt(points.Text) >= CInt(ActualHighscores.lblS0.Text) Then
                iScore = CInt(points.Text)
                LoadScore()
                iPlace = 0
                bHighscorecheck = False
                Highscores.Show()
            ElseIf CInt(points.Text) >= CInt(ActualHighscores.lblS1.Text) Then
                iScore = CInt(points.Text)
                LoadScore()
                iPlace = 1
                bHighscorecheck = False
                Highscores.Show()
            ElseIf CInt(points.Text) >= CInt(ActualHighscores.lblS2.Text) Then
                iScore = CInt(points.Text)
                LoadScore()
                iPlace = 2
                bHighscorecheck = False
                Highscores.Show()
            ElseIf CInt(points.Text) >= CInt(ActualHighscores.lblS3.Text) Then
                iScore = CInt(points.Text)
                LoadScore()
                iPlace = 3
                bHighscorecheck = False
                Highscores.Show()
            ElseIf CInt(points.Text) >= CInt(ActualHighscores.lblS4.Text) Then
                iScore = CInt(points.Text)
                LoadScore()
                iPlace = 4
                bHighscorecheck = False
                Highscores.Show()
            End If
        End If
    End Sub
    Private Sub mnu1Highscores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu1Highscores.Click
        LoadScore()
        ActualHighscores.Show()
    End Sub
    Private Sub mnu4About_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu4About.Click
        About.Show()
    End Sub
    Private Sub mnu4Instructions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu4Instructions.Click
        Instructions.Show()
    End Sub
    Private Sub mnu3On_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu3On.Click
        bSound = True
        mnu3On.Checked = True
        mnu3Off.Checked = False
    End Sub
    Private Sub mnu3Off_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu3Off.Click
        bSound = False
        mnu3Off.Checked = True
        mnu3On.Checked = False
    End Sub
End Class
