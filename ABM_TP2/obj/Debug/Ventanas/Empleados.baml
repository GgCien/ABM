   M S B A M L   `   `   `  ����B  >ABM_TP2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:ABM_TP2.VentanasABM_TP2.Ventanas  5   	        ABM_TP2.Ventanas.Empleados   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:ABM_TP2.Ventanas     5   	     � Title$  	Empleados��5   	   $	��450��6   $	��800��6(    � WindowStartupLocation$ CenterScreen=�64   .��5	      � ���	#FFF0F0F0.+�5
   
   o� $��	0,0,0,395q�6   .@�5      m� -   5        $��Cargos��5      6'   m� 5      -   5        $��Accesos��5      6(   m� 5      -   5        $��Mantenimiento��5      .@�5      m� -   5        $��Mant. Cargo��5      60   m� 5      -   5        $��Mant. Acceso��5      61   5      m� 5      -   5        $��Cerrar Sesión��5      6.   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dtgEmpleados��5      
���   �$��10,217,10,40q�6h      CanUserAddRows .     AutoGenerateColumns .  ���	#FF6C6C6C   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Legajo��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *Legajo+  5      $ Nombre��6%    65   �� *Nombre+  5      $ Apellido��6%    67   �� *
Apellido+  5      $ Fecha Nacimiento��6%    6?   �� *
Nacimiento+  5      $ 
Fecha Alta��6%    69   �� *Alta+  5      $ Cargo��6%    64   �� *Descripcion+  5      $ Estado��6%    65   �� *Estado+5      �� 5   
   -   5        $��Nuevo��5      $
��Left=�6!   $��	10,0,0,10q�6<   $��95��6O   $��25��6Z   $��Bottom=�6f   $
��Bold"�6�   6�   �� 5   
   -	   5        $��Editar��5      $y�	Collapsed=�6"   $
��Left=�69   $��
110,0,0,10q�6T   $��95��6h   $��25��6s   $��Bottom=�6   $
��Bold"�6�   6�   �� 5    
   -
   5        $��Eliminar��5       $
��Left=�6$   $��
110,0,0,10q�6?   $��95��6S   $��25��6^   $��Bottom=�6j   $
��Bold"�6�   6�   �� 5!   
   -   5        $��Salir��5!      $��	0,0,10,10q�6!   $��Right=�64   $��95��6P   $��25��6[   $��Bottom=�6g   $
��Bold"�6�   6�   �� 5"   
   $��/Icons/isipp-bordo.png��6   $
��Left=�60   $	��100��6K   $��	10,26,0,0q�6X   $	��Top=�6k   $��90��6�   �� 5#   
   $��
ISIPP 1206��6   $
��Left=�6%   $��
105,71,0,0q�6@   $	��Top=�6T   ���	#FF6B1414$��22(�6�   $(��"Bahnschrift SemiBold SemiCondensed)�6�   �� 5$   
   $
��Left=�6   $��91��6.   $��
Buscar por��6:   $��
10,121,0,0q�6N   $	��Top=�6b   $	��248��6z   
���   �6�   �� 5%   
   $��Legajo��6   $
��Left=�6!   $��
39,162,0,0q�6<   $	��Top=�6P   �� 5&   
   -   5         ��Name$ txtBuscarLegajo��5&      $
��Left=�6+   $��
85,166,0,0q�6F   	 �� TextWrapping$
	 Wrap=�6Z   $	��Top=�6n   $	��120��6�   6�   �� 5'   
   $
��Left=�6   $��91��6.   $��
Buscar por��6:   $��263,121,0,0q�6N   $	��Top=�6c   $	��261��6{   
���   �6�   �� 5(   
   $��Cargo��6   $
��Left=�6    $��306,162,0,0q�6;   $	��Top=�6P   �� 5)   
   -   5        
 ��Name$
 cmbCargoBuscar��5)      $
��Left=�6+   $��353,164,0,0q�6F   $	��Top=�6[   $	��129��6s   6   �� 5*   
   -   5         ��Name$ lblFecha��5*      $�� ��6"   $��	0,26,10,0q�6-   $	��Top=�6@   $��Right=�6X   $��Right=�6t   $��Center=�6�   �� 5+   
   -   5        $ txtEliminar��5+      $
��Left=�6'   $��529,194,0,0q�6B   $
	 Wrap=�6W   $	��Top=�6k   $��30��6�   
�������$y�	Collapsed=�6�   �� 5,   
   -   5         ��Name$ btnCancelar��5,      $��Cancelar��6&   $
��Left=�69   $��544,158,0,0q�6T   $	��Top=�6i   $
��Bold"�6�   $��95��6�   $��25��6�   $y�	Collapsed=�6�   �� 5-   
   -   5        $ 
lblUsuario��5-      $�� ��6$   $��	0,52,10,0q�6/   $	��Top=�6B   $��Right=�6Z   $	��280��6v   $��Right=�6�   �� 5.   
   $��/Icons/QR.png��6   $��Right=�6'   $	��124��6C   $��	0,83,12,0q�6P   $	��Top=�6c   $	��105��6{   5/      50      