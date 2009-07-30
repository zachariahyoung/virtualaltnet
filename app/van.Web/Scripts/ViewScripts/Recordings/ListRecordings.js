Ext.onReady(function() {
    function formatDate(value){ return value ? value.dateFormat('F d, Y') : '';  };
    function renderdate(value){ return value.dateFormat('M j, Y, g:i a');}
    Ext.state.Manager.setProvider(new Ext.state.CookieProvider());
    Ext.QuickTips.init();

    SharpJs.RecordingsStore = new Ext.data.JsonStore({
        data: SharpJs.RecordingsData,
        fields: [
                {name:'Id'}
			,   {name: 'Title' }
			,   {name: 'Speaker' }
			,   {name:'UserGroup'}
			,   {name: 'Date', type: 'date'},
			,   {name:'Duration'}
		],
        sortInfo: { field: 'Date', direction: 'DESC' }
    });

    SharpJs.RecordingsColumnModel = new Ext.grid.ColumnModel([
			{ header: 'Title', dataIndex: 'Title', sortable: true }
			, { header: 'Speaker', dataIndex: 'Speaker', sortable: true }
			, { header: 'User Group', dataIndex: 'UserGroup', sortable: true }
			,{ header: 'Date', dataIndex: 'Date', sortable: true, renderer:Ext.util.Format.dateRenderer('m-d-Y')}
            ,{ header: 'Duration', dataIndex: 'Duration', sortable: true }
        ]);

    SharpJs.RecordingsColumnModel.defaultSortable = true;

    // create the grid
    SharpJs.RecordingsGrid = new Ext.grid.GridPanel({
        ds: SharpJs.RecordingsStore,
        cm: SharpJs.RecordingsColumnModel,
        sm: new Ext.grid.RowSelectionModel({ singleSelect: true }),
        renderTo: 'divRecordingsGrid',
        width: Ext.GRID_WIDTH,
        height: Ext.GRID_HEIGHT,
        stripeRows: true,
        viewConfig: {
            forceFit: true,
            emptyText: 'No recordings were found.'
        },
        // inline toolbars
         tbar: [{
            text: 'New...',
            tooltip: 'Create new Recording',
            handler: function() {
                SharpJs.RecordingsGrid.suspendEvents();
                window.location.href = SharpJs.RootUrl + 'Recordings/Create';
            },
            iconCls: 'add'
        }, '-', {
            text: 'Edit...',
            tooltip: 'Edit selected Recording',
            handler: function() {
                var selected = SharpJs.RecordingsGrid.getSelectionModel().getSelected();

                if (selected) {
                    SharpJs.RecordingsGrid.suspendEvents();
                    window.location.href = SharpJs.RootUrl + 'Recordings/Edit/' + selected.data.Id;
                } else {
                    Ext.Msg.alert('Edit Recording', 'Please select a recording to edit.');
                }
            },
            iconCls: 'edit'
        }, '-', {
            text: 'Delete...',
            tooltip: 'Delete selected InspectionItem',
            handler: function() {
                var selectedRow = SharpJs.RecordingsGrid.getSelectionModel().getSelected();

                if (selectedRow) {
                    Ext.Msg.confirm('Confirm', 'Really delete?', function(confirmation) {
                        if (confirmation == 'yes') {
                            SharpJs.RecordingsGrid.deleteRecording(selectedRow);
                        }
                    });
                } else {
                    Ext.Msg.alert('Delete Use', 'Please select a recording to delete.');
                }
            },
            iconCls: 'remove'
        }, '->'],
        deleteRecording: function(selectedRow) {
            var conn = new Ext.data.Connection();

            conn.request({
                url: SharpJs.RootUrl + 'Recordings/Delete/',
                method: 'POST',
                params: {
                    'id': selectedRow.data.Id,
                    '__RequestVerificationToken': $("input[name='__RequestVerificationToken']").val()
                },
                success: function(response) {
                    SharpJs.RecordingsStore.remove(selectedRow);
                    SharpJs.ShowDynamicMessage('The recording was successfully deleted.');
                },
                failure: function() {
                    Ext.Msg.alert('Error', 'Sorry, something went wrong. Please try again.');
                }
            });
        },
//        bbar: new Ext.PagingToolbar({
//        pageSize: 15,
//        store: SharpJs.RecordingsStore,
//        displayInfo: true,
//        displayMsg: 'Record {0} - {1} of {2}',
//        emptyMsg: "No records found"
//        }),
       
        plugins: [new Ext.ux.grid.Search({
            position: 'top',
            mode: 'local'
        })]
    });

    // show record on double-click
    SharpJs.RecordingsGrid.on("rowdblclick", function(grid, row, e) {
        grid.suspendEvents();
        window.location.href = SharpJs.RootUrl + 'Recordings/Show/' + grid.getStore().getAt(row).data.Id;
    });
});
