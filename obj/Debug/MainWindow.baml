   M S B A M L   `   `   `  ����C  ?QuizTime, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:QuizTimeQuizTime  5   	       QuizTime.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:QuizTime     5   	     � Title$  
MainWindow��5   	   $	��630��6   $
��1300��6)   .��5	      � 
�������$	��700��6   $
��1400��6*   .+�5
   
   �� -   5        $��textBlockHeading��5
   Q   $��32��6   $
��Left=�6    $��16, 15, 0, 0q�6;   $��Quizes��6i   $	��Top=�6w   6�   � 5   
   $
��Left=�6   $	��585��6*   $	��Top=�67   $
��1270��6O   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��dgQuizes��5         AutoGenerateColumns .  $
��Left=�6C   $   HorizontalScrollBarVisibility$ Disabled=�6^   $��14, 55, 0, 46q�5      $
��1350��6.      CanUserResizeRows .     CanUserAddRows .  ��6;   ��  �� Path$ LoadDataBinding�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Quiz��6E      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6S   	   
IsReadOnly	 . 1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6)   �� $ ID�6^     5      $
 Naam��6K   $	 250 6Y   	 . 
 6)   �� $ QuizNaam�6e   4  .System.Windows.Controls.DataGridTemplateColumn  5      $ 50 6-      CellTemplate 5      �� 5      .R�5   "   �� -   5        $��Spelen��5   )   6:   5      5        5      $ 50 6-    5      �� 5      .R�5   "   �� -   5        $
��Edit��5   )   68   5      5!        5#      $ 50 6-    5$      �� 5%      .R�5&   "   �� -   5        $��Delete��5&   )   6:   5'      5)        5+      $ 75 6-    5,      �� 5-      .R�5.   "   �� -   5        $��	Questions��5.   )   6=   5/      51      53      �� 55      -   5        $��btnAdd��55      $��	Toevoegen��6#   $
��Left=�67   $��1195, 554, 0, 0q�6R   $	��Top=�6k   $��75��6�   56      57      58      