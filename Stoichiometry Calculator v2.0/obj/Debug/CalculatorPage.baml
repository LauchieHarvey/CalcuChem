   M S B A M L   `   `   `  ����X  TStoichiometry Calculator v2.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:Stoichiometry_Calculator_v2._0Stoichiometry_Calculator_v2._0  5      3    -Stoichiometry_Calculator_v2._0.CalculatorPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >local,clr-namespace:Stoichiometry_Calculator_v2._0     5        N� Title$  CalculatorPage��5	      .��5      � .+�5   
   �� -   5         ��Name$ equationFieldsPanel��5   &   {�.  �� Orientation$ 
Horizontal=�6C   $	��Top=�6\   $
��Left=�6t   $��20 30q�6�   $
��Auto��6�   $
��Auto��6�   .+�5      �� -   5         ��Name$ equationTextBox��5      $��3q�6/   $��
10 10 0 10q�6C   $	��400��6W   $	��400��6f   $��50��6r   $��30��6~   $��Center=�6�   $��Center=�6�   $��18(�6�   �� 5      -   5         ��Name$ submitEquationButton��5      $��Submit��63   
�������$
��0 10q�6W   $��5q�6e   $
��Bold"�6q   ���#B6329F6�   �� 5      -   5         ��Name$ isBalancedCheckBox��5       d� 	IsChecked$
 TrueY�63   $��Center=�6D   $��10q�6_   .��6k   	Balanced?6v   5      � 5   
   -   5         �Name$ SpeciesMassFieldsGrid��5   <   $��Center=�6   {�.   � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��* �6#   �� 5      $��* �6#   	 � RowDefinitions	 5      �� 5      $��* �6    .+�5      � $��0��6   $��0��6#   $
��Left=�60   $��10 0 0 0q�6K    5      �� 5      $��* �6'   �� 5      $��* �6'   	 5       �� 5!      $��* �6$   �� 5"      $��* �6$   .+�5%      �� $��0��6   $��0��6,   $��Center=�69   $��Known Species��6T   $��16(�6i   �� 5&      -   5        
 ��Name$
 knownSpeciesComboBox��5&      $��1��69   $��0��6I   $��10q�6V   $��80��6b   $��30��6p   $��Center=�6   6�   �� 5(      $��0��6   $��1��6,   $��Center=�69   $��Unknown Species��6T   $��16(�6k   �� 5)      -   5        $
 unknownSpeciesComboBox��5)      $��1��6;   $��1��6K   $��10q�6X   $��80��6d   $��30��6r   $��Center=�6�   6�   5*      �� 5+      $��1��6   $��0��6)   $ 
Horizontal=�66   $��Center=�6O   $��Center=�6k   .+�5,      �� -   5        $ massMolesInput��5,      $	��100��63   $��40��6B   $��16(�6Q   $��3q�6_   $��Center=�6s   $��Center=�6�   $��0 0 10 0q�6�   � 5-       5.      �� 5/      $��* �6+   �� 50      $��* �6+   	 52      �� 53      $��* �6(   �� 54      $��* �6(   .+�56      �� $��0��6    $��0��60   $��Moles��6=   $��16(�6J   	� 57      -	   5         	�Name$ Moles��57   "   $��1��61   $��0��6A    	� 	GroupName$ MassOrMoles��6N   $��Center=�6f   $
 TrueY�6�   $��5q�6�   �� 59      $��0��6    $��1��60   $
��Mass��6=   $��16(�6I   	� 5:      $��1��6"   $��1��62   $ MassOrMoles��6?   $��Center=�6W   $��5q�6r   5;      5<      �� 5=      -
   5        $��2��5=      $��0��6%   $��Submit��62   $��50 30q�6C   $��3q�6R   $
��Bold"�6f   
�������$��18(�6�   ���#B6329F6�   5>      5?      5@      