   M S B A M L   `   `   `  ����B  >ABM_TP2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ABM_TP2.MantenimientoABM_TP2.Mantenimiento  5   	   (    "ABM_TP2.Mantenimiento.MantEmpleado   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:ABM_TP2.Mantenimiento     5   	     � Title$  MantEmpleado��5   	   $	��423��6   $	��325��6+    � WindowStartupLocation$ CenterScreen=�67   .��5	      � ���	#FFF0F0F0.+�5
   
   �� -   5         ��Name$ 	lblLegajo��5
      $��
Legajo N°��6#   $
��Left=�67   $��	32,46,0,0q�6R   $	��Top=�6e   �� 5   
   $��Nombre��6   $
��Left=�6!   $��	32,72,0,0q�6<   $	��Top=�6O   �� 5   
   $��Apellido��6   $
��Left=�6#   $��	32,98,0,0q�6>   $	��Top=�6Q   �� 5   
   $��
Nacimiento��6   $
��Left=�6%   $��
32,123,0,0q�6@   $	��Top=�6T   �� 5   
   $��
Fecha Alta��6   $
��Left=�6%   $��
32,150,0,0q�6@   $	��Top=�6T   �� 5   
   $��Cargo��6   $
��Left=�6    $��
32,176,0,0q�6;   $	��Top=�6O   �� 5   
   $��Estado��6   $
��Left=�6!   $��
30,212,0,0q�6<   $	��Top=�6P   �� 5   
   -   5         ��Name$ txtApellido��5      $
��Left=�6'   $��108,102,0,0q�6B    �� TextWrapping$
 Wrap=�6W   $	��Top=�6k   $	��145��6�   �� 5   
   -   5        $ 	txtNombre��5      $
��Left=�6%   $��
108,76,0,0q�6@   $
 Wrap=�6T   $	��Top=�6h   $	��145��6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ dtpAlta��5      $
��Left=�6&   $��108,152,0,0q�6A   $	��Top=�6V   �� 5   
   -   5         ��Name$ cmbCargoEmpleado��5      $
��Left=�6-   $��108,181,0,0q�6H   $	��Top=�6]   $	��145��6u   �� 5   
   -   5         ��Name$ 	chbEstado��5      $��Activo/No Activo��6&   $
��Left=�6A   $��108,217,0,0q�6\   $	��Top=�6q   �� 5   
   -   5        $ 	txtLegajo��5      $
��Left=�6%   $��
108,50,0,0q�6@   $
 Wrap=�6T   $	��Top=�6h   $��72��6�   {�.  ���	#FFF0F0F0���	#FFF0F0F06�     5   
   -   5        $ dtpNacimiento��5      $
��Left=�6,   $��108,124,0,0q�6G   $	��Top=�6\   �� 5   
   $	��275��6   $��Registro��6    $��	10,10,8,0q�62   $	��Top=�6E   �� 5   
   -	   5        $��Agregar��5      $
��Left=�6#   $��	44,0,0,66q�6>   $��95��6Q   $
��Bold"�6\   $��25��6n   $��Bottom=�6z   6�   �� 5   
   -
   5        $��Cancelar��5      $
��Left=�6$   $��
194,0,0,66q�6?   $��95��6S   $
��Bold"�6^   $��25��6p   $��Bottom=�6|   6�   5      5      