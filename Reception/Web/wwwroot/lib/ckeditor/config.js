CKEDITOR.editorConfig = function (config) {
    // Define changes to default configuration here. For example:
    // config.uiColor = '#AADC6E';
    config.contentsLangDirection = 'rtl';
    config.language = 'fa';
    config.filebrowserImageUploadUrl = '/file-upload';
    //config.toolbar = 'My';

    config.toolbarGroups = [
        { name: 'clipboard', groups: ['clipboard', 'undo'] },
        { name: 'editing', groups: ['find', 'selection', 'spellchecker'] },
        { name: 'links' },
        { name: 'insert' },
        { name: 'forms' },
        { name: 'tools' },
        { name: 'document', groups: ['mode', 'document', 'doctools'] },
        { name: 'others' },
        '/',
        { name: 'basicstyles', groups: ['basicstyles', 'cleanup'] },
        { name: 'paragraph', groups: ['list', 'indent', 'blocks', 'align', 'bidi'] },
        { name: 'styles' },
        { name: 'colors' },
        { name: 'about' }
    ];
};