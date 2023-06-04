$(document).ready(function () {
    // $('#search_field').attr('placeholder', 'NEMANJA VIDDDDDIIIICCC!');

    console.log(".ready function");

    /**
     * 
     */
    $("#get_search").click(function () {

        var user_search_query = $("#search_field").val();

        //console.log(".Click TEST");

        // $("h1").append(search_query);
        clean_search_query(user_search_query);
    });
    

});




String.prototype.format = function () {
    // store arguments in an array
    var args = arguments;
    // use replace to iterate over the string
    // select the match and check if the related argument is present
    // if yes, replace the match with the argument
    return this.replace(/{([0-9]+)}/g, function (match, index) {
        // check if the argument is present
        return typeof args[index] == 'undefined' ? match : args[index];
    });
};





/**
 * Take users search query and partition it by word, then remove 
 * non-key words from search query(e.g 'and', 'the', 'it', ...)
 * 
 * @param {string} "Users search query"
 * @returns {Array} "Array of cleaned key words ready for db query use"
 */
function clean_search_query(str_query) {

    //var str_low_query = str_query.toLowerCase();                    //All to lowercase
    //str_special_query = str_low_query.replace(/[^a-z ]/g, "")       //Remove special characters
    //var query_words = str_special_query.split(' ');                 //Now in array
    //var filtered_words = filter_search_words(query_words);          //Filter out non-keywords

    //var my_query = construct_sql_query(filtered_words);             //Make sql query in string format

    var query_words = str_query.split(' ');
    var my_query = query_words.toString();
    //console.log("MY QUERY TEST: ", my_query.toString());


    var response = "";

    //Send
    $.ajax({                //https://stackoverflow.com/questions/16245277/function-always-returns-the-same-value
        type: "GET",
        headers: { "cache-control": "no-cache" },
        //cache: false,
        url: "/Search/Search",
        data: { param_search: my_query },
        
        beforeSend: function () {
            // setting a timeout
            console.log("Before Send TEST: " + my_query);
        },
        success: function (response) {
            console.log("my response: ", response);
            update_search_table(response);

        }, error: function (request, status, error) {
            console.log("ERROR: ", error);

        }

    });

}







/**
 * Update 'search_table' in HTML Index
 * @param {JSON} table_rows
 */
function update_search_table(table_rows) {

    // deserialise 'table_rows' from json to array of strings/ or tuples
    // then print all on site

    
    var my_table = $("#search_result");

    var markup_header = "<tr><th>Title</th><tr>";
    var markup_row = "<tr><td>{0}</td></tr>";


    my_table.append(markup_header);



    my_table.empty();

    var search_row_arr;
    var title;
    var my_row;
    for (var i = 0; i < table_rows.length; i++) {
        search_row_arr = table_rows[i].split(", ");
        title = search_row_arr[1];
        my_row = markup_row.format(title);

        my_table.append(my_row);
    }



}


