   M S B A M L   `   `   `  ����B  >ABM_TP1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:ABM_TP1ABM_TP1  5   	       ABM_TP1.VentaRegistro   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:ABM_TP1     5   	     � Title$  VentaRegistro��5   	   $	��346��6   $	��332��6,   .��5	      � .+�5
   
   �� -   5         ��Name$ btnConfirmar��5
      $��	Confirmar��6'   $
��Left=�6;   $��
74,260,0,0q�6V   $	��Top=�6j   $��75��6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dtgRegistro��5      $��Center=�6(   $��81��6E   $��	0,250,0,0q�6Q   $	��Top=�6d   $	��256��6|   $y�	Collapsed=�6�   �� 5   
   -   5         ��Name$ txtNom��5      $
��Left=�6"   $��
105,76,0,0q�6=    �� TextWrapping$
 Wrap=�6Q   $	��Top=�6e   $	��135��6}   6�   �� 5   
   -   5        $ txtApe��5      $
��Left=�6"   $��105,105,0,0q�6=   $
 Wrap=�6R   $	��Top=�6f   $	��135��6~   �� 5   
   -   5        $ 	txtNomUsu��5      $
��Left=�6%   $��105,132,0,0q�6@   $
 Wrap=�6U   $	��Top=�6i   $	��135��6�   �� 5   
   -   5        $ 	txtCorreo��5      $
��Left=�6%   $��105,159,0,0q�6@   $
 Wrap=�6U   $	��Top=�6i   $	��200��6�   �� 5   
   $��Nombre��6   $
��Left=�6!   $��	26,69,0,0q�6<   $	��Top=�6O   �� 5   
   $��Apellido��6   $
��Left=�6#   $��	26,98,0,0q�6>   $	��Top=�6Q   �� 5   
   $��Nom.Usuario��6   $
��Left=�6&   $��
26,126,0,0q�6A   $	��Top=�6U   �� 5   
   $��Correo��6   $
��Left=�6!   $��
26,153,0,0q�6<   $	��Top=�6P   �� 5   
   -   5        $ 	btnVolver��5      $��Cancelar��6$   $
��Left=�67   $��194,260,0,0q�6R   $	��Top=�6g   $��75��6   6�   �� 5   
   $��Registro��6   $
��Left=�6#   $��40��6>   $��	23,10,0,0q�6J   $	��Top=�6]   $��98��6u   $��20(�6�   �� 5   
   $��Contraseña��6   $
��Left=�6%   $��
26,181,0,0q�6@   $	��Top=�6T   G� 5   
   -   5         G�Name$ txtPass��5      $
��Left=�6'   $��105,186,0,0q�6B   $	��Top=�6W   $	��135��6o   6{   5      5      