   M S B A M L   `   `   `  ����B  >ABM_TP2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ABM_TP2.MantenimientoABM_TP2.Mantenimiento  5   	   %    ABM_TP2.Mantenimiento.MantCargo   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:ABM_TP2.Mantenimiento     5   	     � Title$  	MantCargo��5   	   $	��341��6   $	��356��6(    � WindowStartupLocation$ CenterScreen=�64   .��5	      � ���	#FFF0F0F0.+�5
   
   �� -   5        $��Editar��5
      $
��Left=�6"   $��	10,0,0,33q�6=   $��95��6P   $
��Bold"�6[   $��25��6�   $��Bottom=�6�   �� 5   
   -   5        $��Eliminar��5      $
��Left=�6$   $��
110,0,0,33q�6?   $��95��6S   $
��Bold"�6^   $��25��6�   $��Bottom=�6�   �� 5   
   -   5        $��Salir��5      $��	0,0,10,33q�6!   $��Bottom=�64   $��25��6O   $
��Bold"�6[   $��Right=�6�   $��95��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dtgCargo��5      
���   �   CanUserAddRows .  $��10,71,10,71q�6P   ���	#FF6C6C6C6�   �� 5   
   $��Cód. Cargo��6   $y�	Collapsed=�6%   $
��Left=�6<   $��
68,292,0,0q�6W   $	��Top=�6k   �� 5   
   $��Descripción��6   $
��Left=�6&   $��	13,15,0,0q�6A   $	��Top=�6T   �� 5   
   $��Estado��6   $
��Left=�6!   $��	13,41,0,0q�6<   $	��Top=�6O   �� 5   
   -   5         ��Name$ txtCodCargo��5      $y�	Collapsed=�6'   $
��Left=�6>   $��146,296,0,0q�6Y    �� TextWrapping$
 Wrap=�6n   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $ txtDescripcion��5      $
��Left=�6*   $��	90,19,0,0q�6E   $
 Wrap=�6X   $	��Top=�6l   $	��152��6�   �� 5   
   -   5         ��Name$ 	chbEstado��5      $��Habilitado/Deshabilitado��6&   $
��Left=�6I   $��	90,47,0,0q�6d   $	��Top=�6w   5      5      