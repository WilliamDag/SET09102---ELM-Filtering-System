   M S B A M L   `   `   `  ����P  LELM_Filtering_Service, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:ELM_Filtering_Service.ViewsELM_Filtering_Service.Views  5      -    'ELM_Filtering_Service.Views.ViewMessage   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:ELM_Filtering_Service.Views     5      ���#EFF0F5.��5
      �   � ColumnDefinitions  5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� -   5        $��rect_Border��5      ���#E9EAEF$��10q�6:   $��4��6O   $��73��6c   $	��Top=�6o   $	��650��6�   $��Center=�6�   $��0,0,0.333,0q�6�   �� 5   
   -   5        $��rect_Header��5      ���#FCFDFF$��Center=�66   $��70��6S   $	��Top=�6_   $	��650��6w   $��4��6�   $��0,0,0.333,0q�6�   �� 5   
   -   5        $��	txt_Login��5      $��0��6@   $��3��6M   $��Right=�6]   $	��Top=�6y   $	��170��6�   $��0,25,40.333,0q�6�   $��15(�6�   ���#012F4D �� TextAlignment$ Center=�6�   ��6%   �� *	TextTitle+6�   �� 5   
   -   5        $��ic_ReviewMessage��5      $��Center=�6/   $��20q�6L   $��Bottom=�6Y   ���#504C57$��1q�6�   $��3��6�   $	��400��6�   $��0 0 0 30q�6�   $	��350��6�   $��3��6�   .@�5      �� -   5        $��
txt_ReadID��5      $��30��6B   $��Tahoma)�6N   $��Oblique$�6b    �� Padding$ 2q�6v   ���#FCFDFF��6*   �� *ReadID+6�   �� 5      -   5        $��txt_ReadSender��5      $��30��6J   $��Tahoma)�6V   $��Oblique$�6j   $��	0 10 0 10q�6~   $ 2q�6�   ���#FCFDFF��6.   �� *
ReadSender+6�   �� 5      -   5        $��sv_Body��5      $
��Auto=�6*   $��0q�6M   $	��260��6X   .��5      �� -   5        $��txt_ReadBody��5      $
��Wrap=�6J   $��Tahoma)�6^   $��0,8,0,-2q�6r   $
 10 5q�6�   ���#FCFDFF��60   �� *
ReadBody+6�   5      5      �� 5   
   -	   5        $��btn_PreviousFile��5      $��Right=�6W   $��Bottom=�6s   $��50��6�   $��60��6�   $��
0 0 110 10q�6�   $��1��6�   ��6)   �� *PreviousFileButtonCommand+��6�   Z� ��6�   Z� .��5       �� -
   5        $��img_PreviousFile��5       $��/Resources/Previous.png��6,   5!      �� 5"   
   -   5        $��btn_NextFile��5"      $
��Left=�6O   $��Bottom=�6j   $��50��6�   $��60��6�   $��
110 0 0 10q�6�   $��2��6�   $��1��6�   ��6%   �� *NextFileButtonCommand+��6�   Z� ��6�   Z� .��5#      �� -   5        $��img_NextFile��5#      $��/Resources/Next.png��6(   5$      �� 5%   
   -   5         ��Name$ cb_FileSelect��5%      $	��100��6r   $��20��6~   $��0��6�   $��0 0 20 0q�6�   $��Bottom=�6�   $��Right=�6�   $��2��6�   $��2��6�   ��6*   �� *	ListFiles+ �� SelectedItem 6L   �� *SelectedFile+6�   �� 5&   
   -   5        $��btn_LoadFile��5&      $��Right=�6v   $��Bottom=�6�   $	��100��6�   $��30��6�   ���#F06060$��0q�6�   ���#E9EAEF$��	0 0 20 40q�6  $��2��6  ��6%   �� *LoadFileButtonText+��6L   �� *LoadFileButtonCommand+6  5'      5(      