import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';

import { ApiDocumentService } from '../../service/api-document.service';
import { IDocument } from './../../models/IDocument';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { DialogDocumentComponent } from './dialog/dialog-document.component';
import { element } from 'protractor';
import { DialogDeleteComponent } from './../../common/dialog-delete/dialog-delete.component';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-document',
  templateUrl: './document.component.html',
  styleUrls: ['./document.component.scss'],
})
export class DocumentComponent implements OnInit {
  @ViewChild(MatPaginator) private _paginator: MatPaginator;
  @ViewChild(MatSort) private _sort: MatSort;
  public dataSource: MatTableDataSource<IDocument>;
  public displayedColumns: string[] = [
    'IdTipoDoc',
    'Codigo',
    'Nombre',
    'Descripcion',
    'Action',
  ];

  private _dialogWidth: string = '30em';
  private _duration: number = 5000;

  constructor(
    private _apiDocumentService: ApiDocumentService,
    private _dialog: MatDialog,
    private _snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {
    this.getDocument();
  }

  getDocument(): void {
    this._apiDocumentService.get().subscribe(
      (res) => {
        if (res.result) {
          this.dataSource = new MatTableDataSource(res.data);
          this.dataSource.paginator = this._paginator;
          this.dataSource.sort = this._sort;
        }
      },
      (err) => {
        this._snackBar.open('Ocurrio un error al obtener los datos.', '', {
          duration: this._duration,
        });
        console.error(err);
      }
    );
  }

  applyFilter(event: Event): void {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue?.trim().toLowerCase() ?? '';

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  openAdd(): void {
    this.open();
  }

  openUpdate(element: IDocument): void {
    this.open(element);
  }

  private open(element: IDocument = null) {
    let dialogRef: MatDialogRef<DialogDocumentComponent>;

    dialogRef = this._dialog.open(DialogDocumentComponent, {
      data: element,
      width: this._dialogWidth,
    });

    dialogRef.afterClosed().subscribe((res) => {
      if (res) {
        this.getDocument();
      }
    });
  }

  openDelete(element: IDocument): void {
    const dialogRef = this._dialog.open(DialogDeleteComponent, {
      data: {
        title: 'Eliminar',
        message: `Esta seguro de querer eliminar este registro. "${element.codigo}"`,
      },
      width: this._dialogWidth,
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this._apiDocumentService.delete(element.idTipoDoc).subscribe(
          (res) => {
            if (res.result) {
              this.getDocument();
              this._snackBar.open(res.message, '', {
                duration: this._duration,
              });
            }
          },
          (err) => {
            this._snackBar.open('Ocurrio un error inesperado.', '', {
              duration: this._duration,
            });
            console.error(err);
          }
        );
      }
    });
  }
}
