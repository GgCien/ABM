   M S B A M L   `   `   `  ����B  >ABM_TP2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ABM_TP2.MantenimientoABM_TP2.Mantenimiento  5   	   &     ABM_TP2.Mantenimiento.MantAcceso   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:ABM_TP2.Mantenimiento     5   	     � Title$  
MantAcceso��5   	   $	��342��6   $	��425��6)    � WindowStartupLocation$ CenterScreen=�65   .��5	      � ���	#FFF0F0F0.+�5
   
   �� -   5        $��Editar��5
      $
��Left=�6"   $��	10,0,0,36q�6=   $��95��6P   $
��Bold"�6[   $��25��6m   $��Bottom=�6y   6�   �� 5   
   -   5        $��Eliminar��5      $
��Left=�6$   $��
110,0,0,36q�6?   $��95��6S   $
��Bold"�6^   $��25��6p   $��Bottom=�6|   6�   �� 5   
   -   5        $��Salir��5      $��0,0,9,36q�6!   $
��Bold"�63   $��Right=�6E   $��95��6a   $��25��6l   $��Bottom=�6x   $��1��6�   6�   �� 5   
   $��Empleado��6   $
��Left=�6#   $��	10,10,0,0q�6>   $	��Top=�6Q   �� 5   
   $��Hora Entrada��6   $
��Left=�6'   $��	10,41,0,0q�6B   $	��Top=�6U   �� 5   
   $��Hora Salida��6   $
��Left=�6&   $��	10,72,0,0q�6A   $	��Top=�6T   �� 5   
   -   5         ��Name$ cmbEmpleado��5      $
��Left=�6(   $��	94,14,0,0q�6C   $	��Top=�6V   $	��120��6n   $��2��6z   �� 5   
   -   5         ��Name$ txtHoraEntrada��5      $
��Left=�6*   $��	94,47,0,0q�6E    �� TextWrapping$
 Wrap=�6X   $	��Top=�6l   $	��120��6�   $��2��6�   �� 5   
   -   5        $ txtHoraSalida��5      $
��Left=�6)   $��	94,76,0,0q�6D   $
 Wrap=�6W   $	��Top=�6k   $	��120��6�   $��2��6�   �� 5   
   -   5        $ txtCodAcceso��5      $y�	Collapsed=�6(   $
��Left=�6?   $��	90,76,0,0q�6Z   $
 Wrap=�6m   $	��Top=�6�   $	��120��6�   $��1��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 	dtgAcceso��5      
���   �   CanUserAddRows .  $��10,103,9,66q�6Q   ���	#FF6C6C6C6�   5      5      