   M S B A M L   `   `   `  ����F  BWPF_projekt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WPF_projektWPF_projekt  5   	       WPF_projekt.Studenti   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:WPF_projekt     5   	     � Title$  Studenti��5   	   $	��479��6   $	��800��6'   .��5	      � $��0,0,0,35q�6    � RowDefinitions 5
   
   �� 5      �� 5      $��65 �6   .+�5   
   &   System.Windows.Controls.DataGrid     AutoGenerateColumns$ False��64      CanUserAddRows$ False��6P      CanUserDeleteRows$ False��6g      
IsReadOnly$
 True��6�   $��2��6�   $��	0,0,0,-33q�6�   ��6   �� *
studenti+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ id studenta��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *id_studenta+  5      $ jmeno��6%    64   �� *jmeno+  5      $ prijmeni��6%    67   �� *
prijmeni+  5      $ mesto��6%    64   �� *mesto+  5      $ ulice��6%    64   �� *ulice+  5      $	 psc��6%    62   �� *psc+  5      $ email��6%    64   �� *email+  5      $ misto narozeni��6%    6=   �� *misto_narozeni+  5      $ datum narození��6%    6=   �� *datum_narozeni+  5      $ statni obcanstvi��6%    6?   �� *statni_obcanstvi+  5      $ rodne cislo��6%    6:   �� *rodne_cislo+  5      $
 stat��6%    63   �� *stat+  5      $ telefon��6%    66   �� *	telefon+4  .System.Windows.Controls.DataGridTemplateColumn  5      	   CellTemplate	 5       �� 5!      .R�5"      �� 
 �� Orientation$
 
Horizontal=�6)   .+�5#   "   �� -   5        $��Smazat��5#   @   
���  ��
�������6b   �� 5$   "   -   5        $��Upravit��5$   =   
����  �
�������6a   5%      5&      5(      5*      5+      5,      