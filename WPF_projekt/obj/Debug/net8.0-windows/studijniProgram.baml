   M S B A M L   `   `   `  ����F  BWPF_projekt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WPF_projektWPF_projekt  5   	   !    WPF_projekt.studijniProgram   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:WPF_projekt     5   	     � Title$  studijniProgram��5   	   $	��450��6!   $	��800��6.   .��5	      �  � RowDefinitions 5
   
   �� 5      �� 5      $��65 �6   .+�5   
   &   System.Windows.Controls.DataGrid     AutoGenerateColumns$ False��67      CanUserAddRows$ False��6S      CanUserDeleteRows$ False��6j      
IsReadOnly$
 True��6�   ��6   �� *programList+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ id programu��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *id_programu+  5      $ název��6%    64   �� *nazev+  5      $ zkratka��6%    66   �� *	zkratka+  5      $ popis��6%    64   �� *popis+4  .System.Windows.Controls.DataGridTemplateColumn  5      	   CellTemplate	 5      �� 5      .R�5      �� 
 �� Orientation$
 
Horizontal=�6)   .+�5   "   �� -   5        $��Smazat��5   E   
���  ��
�������6g   �� 5   "   -   5        $��Upravit��5   E   
����  �
�������6i   5      5      5      5"      �� 5$   
   -   5        $��1��5$   /   $��přidat studijní program��6<   5%      5&      