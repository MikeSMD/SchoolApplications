   M S B A M L   `   `   `  ����F  BWPF_projekt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WPF_projektWPF_projekt  5   	       WPF_projekt.StredniSkoly   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:WPF_projekt     5   	     � Title$  StredniSkoly��5   	   $	��450��6   $	��800��6+   .��5	      �  � RowDefinitions 5
   
   �� 5      �� 5      $��65 �6   .+�5   
   &   System.Windows.Controls.DataGrid     AutoGenerateColumns$ False��61      CanUserAddRows$ False��6M      CanUserDeleteRows$ False��6d      
IsReadOnly$
 True��6~   ��6   �� *skoly+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ nazev��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *nazev+  5      $	 typ��6%    62   �� *typ+  5      $
 kraj��6%    63   �� *kraj+  5      $ mesto��6%    64   �� *mesto+  5      $ ulice��6%    64   �� *ulice+  5      $	 psc��6%    62   �� *psc+  5      $ email��6%    64   �� *email+4  .System.Windows.Controls.DataGridTemplateColumn  5      	   CellTemplate	 5      �� 5      .R�5      �� 
 �� Orientation$
 
Horizontal=�6)   .+�5   "   �� -   5        $��Smazat��5   <   
���  ��
�������6^   �� 5   "   -   5        $��Upravit��5   >   
����  �
�������6b   �� 5   "   -   5        $��Programy školy��5   @   
��� � �
�������6l   5       5!      5#      5&      �� 5(   
   $��1��6   .+�5)      �� -   5        $��přidat střední školu��5)   )   $��45��6H   �� 5*      -   5        $��Správa programů��5*   4   5+      5,      5-      