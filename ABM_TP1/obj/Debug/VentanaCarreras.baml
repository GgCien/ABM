   M S B A M L   `   `   `  ����B  >ABM_TP1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:ABM_TP1ABM_TP1  5   	       ABM_TP1.Carreras   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:ABM_TP1     5   	     � Title$  Carreras��5   	   $	��466��6   $	��800��6'    � 	Resources 5	       �� 
TargetType �� Property �� Value'  !System.Windows.Shell.WindowChrome   CaptionHeight   CornerRadius   GlassFrameThickness��%  '�       �� 5
   
   " �6   .�5      ��  �@�WindowStyle$
 None=�6,   �� 5       �@�AllowsTransparency . 63   �� 5       �@ WindowChrome 5        5      $ 0Q�6#   $ 0��65   $ 0q�6F   6`   5      5      5      .��5      �� {�. .@�5   
   �� $��Carreras��6   .��5      � .+�5      �� -   5         ��Name$ txtDescripcion��5      $y�	Collapsed=�62   $
��Left=�6I   $��370,145,0,0q�6d   	 �� TextWrapping$
	 Wrap=�6y   $	��Top=�6�   $	��120��6�   6�   �� 5      -   5        
 ��Name$	
 uno��5      $��Código Clase��6%   $y�	Collapsed=�6<   $
��Left=�6S   $��271,101,0,0q�6n   $	��Top=�6�   �� 5      -   5        $	
 dos��5      $��Descripción��6%   $y�	Collapsed=�6;   $
��Left=�6R   $��271,137,0,0q�6m   $	��Top=�6�   &   System.Windows.Controls.DataGrid  5      -   5          Name$ dtgCarreras��5         CanUserAddRows .  $��154,305,10,10q�6G   $y�	Collapsed=�6�   
�������
���   �   AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Código Carrera��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6a   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6E   �� *	CodClas+6a     5      $ Carrera��6-   $	 175 6^    6>   �� *Descripcion+6^   5      �� 5       -   5         ��Name$ btnNuevo��5       $
��Left=�6+   $��	60,48,0,0q�6F   $	��Top=�6Y   
�������
�������.��5!      �� .+�5"      �� $ ��/Icons/agregar-archivo.png��6    $��20��6D   $��25��6P   6]   �� 5#       �� TextAlignment$ Center=�6$   $��Nuevo��6;   6J   5$      5%      �� 5&      -   5        $ 
btnGuardar��5&      $
��Left=�6-   $��
687,95,0,0q�6H   $	��Top=�6\   
�������
�������$y�	Collapsed=�6�   .��5'      �� .+�5(      �� $��/Icons/disquete.png��6    $��20��6=   $��25��6I   6V   �� 5)      $��Guardar��6$   $ Center=�63   6L   5*      5+      �� 5,      -   5        $ btnModificar��5,      $
��Left=�6/   $��
53,107,0,0q�6J   $	��Top=�6^   
�������
�������.��5-      �� .+�5.      �� $��/Icons/editar.png��6    $��20��6;   $��25��6G   6T   �� 5/      $ Center=�6$   $��	Modificar��6;   6N   50      51      �� 52      -   5        $ btnEliminar��52      $
��Left=�6.   $��
56,166,0,0q�6I   $	��Top=�6]   
�������
�������.��53      �� .+�54      �� $��/Icons/eliminar.png��6    $��20��6=   $��25��6I   6V   �� 55      $ Center=�6$   $��Eliminar��6;   6M   56      57      �� 58      -	   5        $ btnCancelar��58      $
��Left=�6.   $��
56,232,0,0q�6I   $	��Top=�6]   
�������
�������.��59      �� .+�5:      �� $��/Icons/rechazar.png��6    $��20��6=   $��25��6I   6V   �� 5;      $ Center=�6$   $��Cancelar��6;   6M   5<      5=      �� 5>      -
   5        $ 
btnLimpiar��5>      $
��Left=�6-   $��689,155,0,0q�6H   $	��Top=�6]   
�������
�������$y�	Collapsed=�6�   .��5?      �� .+�5@      �� $��/Icons/borrador.png��6    $��20��6=   $��25��6I   6V   �� 5A      $ Center=�6$   $��Limpiar��6;   6L   5B      5C      �� 5D      -   5        $ btnSalir��5D      $
��Left=�6+   $��	65,0,0,33q�6F   
�������
�������$��40��6�   $��Bottom=�6�   .��5E      �� .+�5F      �� $��/Icons/cerrar.png��6    $��20��6;   $��25��6G    J� RenderTransformOrigin$ 0.6,0.5&�6R   6t   �� 5G      $ Center=�6$   $��Salir��6;   6J   5H      5I      �� 5J      $
��Left=�6   $��Acciones��66   $��
10,22,0,14q�6H   $	��139��6\   �� 5K      -   5         ��Name$ opciones��5K      $
��Left=�6-   $	��190��6H   $��Opciones��6U   $��
660,49,0,0q�6g   $	��Top=�6{   $	��101��6�   $y�	Collapsed=�6�   �� 5L      -   5        $ mantenimiento��5L      $
��Left=�62   $	��155��6M   $��Mantenimiento��6Z   $��
229,68,0,0q�6q   $	��Top=�6�   $	��345��6�   $y�	Collapsed=�6�   �� 5M      -   5        $
 lblUsu��5M      $�� ��6(   $��	0,10,10,0q�63   $	��Top=�6F   $��Right=�6^   $��Right=�6�   $	��200��6�   �� 5N      -   5        $ txtIDc��5N      $y�	Collapsed=�6*   $
��Left=�6A   $��370,105,0,0q�6\   $
	 Wrap=�6q   $	��Top=�6�   $	��120��6�   6�   �� 5O      -   5        $ btnActualizar��5O      $y�	Collapsed=�60   $
��Left=�6G   $��
53,107,0,0q�6b   $	��Top=�6v   
�������
�������.��5P      �� .+�5Q      �� $��/Icons/actualizar.png��6    $��20��6?   $��25��6K   6X   �� 5R      $ Center=�6$   $��
Actualizar��6;   6O   5S      5T        5U      -   5        $ 
dtgMostrar��5U       .  
�������
���   � .  $��154,10,10,10q�6�    5V        5W      $ Código Carrera��6-   $ 50 6a    6E   �� *	CodClas+6a     5X      $ Carrera��6-   $	 175 6^    6>   �� *Descripcion+6^   5Z      5[      5\      5]      5^      