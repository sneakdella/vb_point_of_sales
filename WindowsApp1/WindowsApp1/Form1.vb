Public Class Form1
    Public Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim strName As String
        Dim strGreeting As String
        Dim strEmployeeName As String

        strEmployeeName = TextBox9.Text

        strName = TextBox8.Text

        'Will bring up a new window and say "Hello <str>"
        strGreeting = $"Hello {strEmployeeName}"


        MessageBox.Show(strGreeting) 'Display message on computer screen
    End Sub

    'Executes all functions to generate a receipt
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim strName As String
        Dim strGreeting As String
        Dim strGreeting2 As String
        Dim strEmployeeName As String

        strName = TextBox8.Text
        strEmployeeName = TextBox9.Text

        strGreeting = $"Receipt for Customer: {strName}"
        strGreeting2 = $"Employee Name: {strEmployeeName}"

        'Generates Employee and Customer lines in the RichTextBox based on what is entered in the textboxes
        RichTextBox1.Text = strGreeting & vbNewLine & vbNewLine & strGreeting2 & vbNewLine & vbNewLine

        ' Defining the values in the textboxes
        Dim intBurgCheese As Integer
        Dim intBurg As Integer
        Dim intPizzaCheese As Integer
        Dim intPizzaPep As Integer
        Dim intPizzaSlice As Integer
        Dim intMedDrink As Integer
        Dim intLargeDrink As Integer

        ' Defining the prices of each item
        Dim valBurgCheese As Decimal = 2.25
        Dim valBurg As Decimal = 2.0
        Dim valPizzaCheese As Decimal = 5.0
        Dim valPizzaPep As Decimal = 6.0
        Dim valPizzaSlice As Decimal = 1.0
        Dim valMedDrink As Decimal = 1.0
        Dim valLargeDrink As Decimal = 2.0

        ' Decimal Conversion for math
        intBurgCheese = Convert.ToDecimal(TextBox7.Text)
        intBurg = Convert.ToDecimal(TextBox1.Text)
        intPizzaCheese = Convert.ToDecimal(TextBox2.Text)
        intPizzaPep = Convert.ToDecimal(TextBox3.Text)
        intPizzaSlice = Convert.ToDecimal(TextBox4.Text)
        intMedDrink = Convert.ToDecimal(TextBox5.Text)
        intLargeDrink = Convert.ToDecimal(TextBox6.Text)

        'Calculations
        Dim calcBurgCheese As Decimal = intBurgCheese * valBurgCheese
        Dim calcBurg As Decimal = intBurg * valBurg
        Dim calcPizzaCheese As Decimal = intPizzaCheese * valPizzaCheese
        Dim calcPizzaPep As Decimal = intPizzaPep * valPizzaPep
        Dim calcPizzaSlice As Decimal = intPizzaSlice * valPizzaSlice
        Dim calcMedDrink As Decimal = intMedDrink * valMedDrink
        Dim calcLargeDrink As Decimal = intLargeDrink * valLargeDrink

        'Formatting After Calculations to be printed on the RichtTextBox
        Dim cheeseBurger As String = vbNewLine & "Cheese Burger: " & vbTab & calcBurgCheese.ToString("0.00") & vbTab & intBurgCheese
        Dim burger As String = vbNewLine & "Normal Burger: " & vbTab & calcBurg.ToString("0.00") & vbTab & intBurg
        Dim pizzaCheese As String = vbNewLine & "Pizza Cheese: " & vbTab & calcPizzaCheese.ToString("0.00") & vbTab & intPizzaCheese
        Dim pizzaPep As String = vbNewLine & "Pizza Peperoni: " & vbTab & calcPizzaPep.ToString("0.00") & vbTab & intPizzaPep
        Dim pizzaSlice As String = vbNewLine & "Pizza Slice: " & vbTab & calcPizzaSlice.ToString("0.00") & vbTab & intPizzaSlice
        Dim medDrink As String = vbNewLine & "Medium Drink: " & vbTab & calcMedDrink.ToString("0.00") & vbTab & intMedDrink
        Dim largeDrink As String = vbNewLine & "Large Drink: " & vbTab & calcLargeDrink.ToString("0.00") & vbTab & intLargeDrink

        ' First line before Items, Description and Amount
        Dim prntStr As String = vbNewLine & "Item Description" & vbTab & "Amount" & vbTab & "Qty"
        RichTextBox1.AppendText(prntStr)

        ' Checks if values have changed for the amount of each product. 
        ' This makes sure it does Not print any item the customer did Not order!
        ' This also makes sure that if the customer did order something that it will print the formats from the lines above.
        If intBurgCheese > 0 Then
            RichTextBox1.AppendText(cheeseBurger)
        End If
        If intBurg > 0 Then
            RichTextBox1.AppendText(burger)
        End If
        If intPizzaCheese > 0 Then
            RichTextBox1.AppendText(pizzaCheese)
        End If
        If intPizzaPep > 0 Then
            RichTextBox1.AppendText(pizzaPep)
        End If
        If intPizzaSlice > 0 Then
            RichTextBox1.AppendText(pizzaSlice)
        End If
        If intMedDrink > 0 Then
            RichTextBox1.AppendText(medDrink)
        End If
        If intLargeDrink > 0 Then
            RichTextBox1.AppendText(largeDrink)
        End If


        'Beginning Calculations for Total
        Dim cheeseBurgtotal As Decimal = intBurgCheese * valBurgCheese
        Dim burgTotal As Decimal = intBurg * valBurg
        Dim pizzaCheeseTotal As Decimal = intPizzaCheese * valPizzaCheese
        Dim pizzaPepTotal As Decimal = intPizzaPep * valPizzaPep
        Dim pizzaSliceTotal As Decimal = intPizzaSlice * valPizzaSlice
        Dim medDrinkTotal As Decimal = intMedDrink * valMedDrink
        Dim largeDrinkTotal As Decimal = intLargeDrink * valLargeDrink

        'Total Before Discounts
        Dim Total As String = Convert.ToString(cheeseBurgtotal + burgTotal + pizzaCheeseTotal + pizzaPepTotal + pizzaSliceTotal + medDrinkTotal + largeDrinkTotal)

        'Extra Line to make code less redundant for Discounts on Total
        Dim discountTotal As Decimal = (cheeseBurgtotal + burgTotal + pizzaCheeseTotal + pizzaPepTotal + pizzaSliceTotal + medDrinkTotal + largeDrinkTotal)

        'Both Discounts
        If CheckBox1.Checked And CheckBox2.Checked Then
            Dim discountTotal4 As Decimal = (0.75 * discountTotal)
            RichTextBox1.AppendText(vbNewLine & vbNewLine & "Total:" & vbTab & Total)
            RichTextBox1.AppendText(vbNewLine & vbNewLine & "Discounted Total:" & vbTab & discountTotal4.ToString("0.00"))
            'First Discount Only
        ElseIf CheckBox1.Checked Then
            Dim discountTotal2 As Decimal = (0.9 * discountTotal)
            RichTextBox1.AppendText(vbNewLine & vbNewLine & "Total:" & vbTab & Total)
            RichTextBox1.AppendText(vbNewLine & vbNewLine & "Discounted Total:" & vbTab & discountTotal2.ToString("0.00"))
            'Second Discount Only
        ElseIf CheckBox2.Checked Then
            Dim discountTotal3 As Decimal = Convert.ToString(Math.Round(0.9 * discountTotal))
            RichTextBox1.AppendText(vbNewLine & vbNewLine & "Total:" & vbTab & Total)
            RichTextBox1.AppendText(vbNewLine & vbNewLine & "Discounted Total:" & vbTab & discountTotal3.ToString("0.00"))
            'No Discounts
        ElseIf CheckBox1.CheckState = 0 And CheckBox2.CheckState = 0 Then
            RichTextBox1.AppendText(vbNewLine & vbNewLine & "Total:" & vbTab & Total)
            RichTextBox1.AppendText(vbNewLine & vbNewLine & "No Discounts Provided")
        End If

    End Sub

    'A mock void for a receipt
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        RichTextBox1.Text = "** Previous Receipt Voided ** "
    End Sub

    'Returns all values except Employee Name to default strings and clears RichTextBox1
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        TextBox1.Text = 0
        TextBox2.Text = 0
        TextBox3.Text = 0
        TextBox4.Text = 0
        TextBox5.Text = 0
        TextBox6.Text = 0
        TextBox7.Text = 0
        TextBox8.Text = "Customer"
        RichTextBox1.Text = Nothing
    End Sub
End Class
