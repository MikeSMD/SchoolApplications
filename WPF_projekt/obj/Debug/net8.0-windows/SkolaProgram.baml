   M S B A M L   `   `   `  ����F  BWPF_projekt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WPF_projektWPF_projekt  5   	       WPF_projekt.SkolaProgram   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:WPF_projekt     5   	     � Title$  SkolaProgram��5   	   $	��450��6   $	��800��6+   .��5	      �  � RowDefinitions 5
   
   �� 5      �� 5      $��65 �6   .+�5   
   &   System.Windows.Controls.DataGrid     AutoGenerateColumns$ False��6<      CanUserAddRows$ False��6X      CanUserDeleteRows$ False��6o      
IsReadOnly$
 True��6�   ��6   �� *skolaProgramList+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ id školního programu��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6C   �� *id_skola_program+  5      $ 	id školy��6%    67   �� *
id_skoly+  5      $ id programu��6%    6:   �� *id_programu+  5      $ počet míst��6%    69   �� *pocet_volnych_mist+4  .System.Windows.Controls.DataGridTemplateColumn  5      	   CellTemplate	 5      �� 5      .R�5      �� 
 �� Orientation$
 
Horizontal=�6)   .+�5   "   �� -   5        $��Smazat��5   F   
���  ��
�������6h   5      5      5      5!      �� 5#   
   -   5        $��1��5#   .   $��přidat program ke škole��6;   5$      5%      