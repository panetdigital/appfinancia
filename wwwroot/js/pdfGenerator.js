window.jsPDFGenerator = {
    generatePDF: function (transactions) {
        const { jsPDF } = window.jspdf;
        const doc = new jsPDF();

        // Tamanho da página
        const pageWidth = doc.internal.pageSize.getWidth();

        // Data atual
        const currentDate = new Date().toLocaleDateString();

        // Título do relatório (centralizado)
        const title = 'Relatório de Transações';
        const titleX = (pageWidth - doc.getTextWidth(title)) / 2; // Centralizar o título
        doc.setFontSize(16);
        doc.text(title, titleX, 10); // O título estará centralizado

        // Data no canto superior direito
        doc.setFontSize(10);
        doc.text(currentDate, pageWidth - 30, 10); // Data no canto superior direito

        // Espaço após o título
        let startY = 20;

        // Cabeçalhos da tabela
        doc.setFontSize(12);
        doc.text('Descrição', 10, startY);
        doc.text('Valor', 60, startY);
        doc.text('Categoria', 100, startY);
        doc.text('Data', 140, startY);

        // Linha separadora após os cabeçalhos
        doc.line(10, startY + 2, 200, startY + 2);

        // Adiciona as transações uma por uma abaixo do cabeçalho
        startY += 10;
        transactions.forEach((transaction, index) => {
            doc.text(transaction.description, 10, startY + index * 10);
            doc.text(transaction.amount.toString(), 60, startY + index * 10);
            doc.text(transaction.category, 100, startY + index * 10);
            doc.text(new Date(transaction.date).toLocaleDateString(), 140, startY + index * 10);
        });

        // Salva o PDF com o nome especificado
        doc.save('transacoes.pdf');
    }
};
